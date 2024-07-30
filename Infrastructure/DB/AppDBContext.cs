using Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Infrastructure.DB
{
    public class AppDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AppDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FavouritesList> FavouritesLists { get; set; }
        public DbSet<FavouritesListItem> FavouritesListItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ExpiredToken> ExpiredTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Data
            string categoriesJson = File.ReadAllText("CategoriesData.json");
            List<Category> categories = JsonSerializer.Deserialize<List<Category>>(categoriesJson)!;

            string productsJson = File.ReadAllText("ProductsData.json");
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(productsJson)!;

            foreach (Category c in categories)
            {
                builder.Entity<Category>().HasData(c);
            }

            foreach (Product p in products)
            {
                builder.Entity<Product>().HasData(p);
            }
        }

    }
}
