using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.Helpers;
using Core.Services;
using Core.Services_contracts;
using Infrastructure.DB;
using Infrastructure.External_apis;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sieve.Models;
using Sieve.Services;
using Stripe;
using System.Text;

namespace GroceryAPI.Extensions
{
    public static class ServicesRegistrationExtension
    {
        public static WebApplicationBuilder RegisterAndConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IJwtServices, JwtServices>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<ITokenRepository, TokenRepository>();
            builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IFavouritesListItemRepository, FavouritesListItemRepository>();
            builder.Services.AddScoped<IFavouritesListRepository, FavouritesListRepository>();
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<ICartItemServices, CartItemServices>();
            builder.Services.AddScoped<ICartServices, CartServices>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<IFavouritesListItemServices, FavouritesListItemServices>();
            builder.Services.AddScoped<IFavouritesListServices, FavouritesListServices>();
            builder.Services.AddScoped<IOrderItemServices, OrderItemServices>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddScoped<IReviewServices, ReviewServices>();
            builder.Services.AddScoped<ServicesHelpers>();
            builder.Services.AddScoped<ISieveProcessor, SieveProcessor>();
            builder.Services.AddScoped<IPaymentsServices, PaymentsServices>();
            builder.Services.AddScoped<IDeliveryServices, DeliveryServices>();

            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            builder.Services.Configure<SieveOptions>(builder.Configuration.GetSection("Sieve"));

            builder.Services.AddDbContext<AppDBContext>(opt =>
            {
                opt.UseSqlServer(Environment.GetEnvironmentVariable("BEQALTK_DEV_DB_DEFAULT_URL"));
            });

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDBContext>()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, AppDBContext, Guid>>()
                .AddRoleStore<RoleStore<ApplicationRole, AppDBContext, Guid>>();

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;

                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = Environment.GetEnvironmentVariable("BEQALTK_DEV_JWT_ISSUER")!,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("BEQALTK_DEV_JWT_SECRET")!)
                        ),
                };

                opt.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = async ctx =>
                    {
                        var token = ctx.HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
                        if (token != null)
                        {
                            var tokenService = ctx.HttpContext.RequestServices.GetRequiredService<IJwtServices>();
                            if (tokenService.IsExpiredToken(token))
                            {
                                ctx.Fail("Expired token");
                            }
                        }
                    }
                };
            });

            builder.Services.AddAuthorization(opt =>
            {
                opt.AddPolicy("NoAuthenticated", p =>
                {
                    p.RequireAssertion(ctx =>
                    {
                        return !ctx.User.Identity!.IsAuthenticated;
                    });

                });
            });

            StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("BEQALTK_DEV_STRIPE_SECRET");

            return builder;
        }
    }
}
