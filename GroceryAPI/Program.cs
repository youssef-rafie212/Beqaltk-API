using Core.Domain.Entities;
using Core.Domain.Repository_contracts;
using Core.Helpers;
using Core.Services;
using Core.Services_contracts;
using Infrastructure.DB;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace GroceryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            // Handle the circular references
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            builder.Services.AddTransient<IJwtServices, JwtServices>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<ICategoryServices, CategoryServices>();
            builder.Services.AddTransient<ITokenRepository, TokenRepository>();
            builder.Services.AddTransient<ICartItemRepository, CartItemRepository>();
            builder.Services.AddTransient<ICartRepository, CartRepository>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<IFavouritesListItemRepository, FavouritesListItemRepository>();
            builder.Services.AddTransient<IFavouritesListRepository, FavouritesListRepository>();
            builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
            builder.Services.AddTransient<ICartItemServices, CartItemServices>();
            builder.Services.AddTransient<ICartServices, CartServices>();
            builder.Services.AddTransient<ICategoryServices, CategoryServices>();
            builder.Services.AddTransient<IFavouritesListItemServices, FavouritesListItemServices>();
            builder.Services.AddTransient<IFavouritesListServices, FavouritesListServices>();
            builder.Services.AddTransient<IOrderItemServices, OrderItemServices>();
            builder.Services.AddTransient<IOrderServices, OrderServices>();
            builder.Services.AddTransient<IProductServices, ProductServices>();
            builder.Services.AddTransient<IReviewServices, ReviewServices>();
            builder.Services.AddTransient<ServicesHelpers>();

            builder.Services.AddDbContext<AppDBContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
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
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!)),
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();

            // Configure authorization and authentication.
            app.UseAuthentication();
            app.UseAuthorization();

            // Routing
            app.MapControllers();

            app.Run();
        }
    }
}
