using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context=app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetAppliedMigrations().Any()) 
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any()) 
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name="Ram",
                        Description="A boat for one person",
                        Category="Watersports",
                        Price=275
                    },
                    new Product
                    {
                        Name="Lakshman",
                        Description="Protective and fashionable",
                        Category="Watersports",
                        Price=48
                    },
                    new Product
                    {
                        Name = "Sita",
                        Description = "Daughter of earth",
                        Category = "FIFA-approved size and weight",
                        Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Bharat",
                        Description = "Brother of Rama",
                        Category = "Give your playing field a professional touch",
                        Price = 34.95m
                    },
                     new Product
                     {
                         Name = "Hanuman",
                         Description = "Sewak of Rama",
                         Category = "Flat-packed 35,000-seat stadium",
                         Price = 29.95m
                     },
                     new Product
                     {
                         Name = "Human Chess Board",
                         Description = "A fun game for the family",
                         Category = "Chess",
                         Price = 75
                     },
                     new Product
                     {
                         Name = "Bling-Bling King",
                         Description = "Gold-plated, diamond-studded King",
                         Category = "Chess",
                         Price = 1200
                     },
                     new Product
                     {
                         Name = "Human Chess Board",
                         Description = "A fun game for the family",
                         Category = "Chess",
                         Price = 75
                     }
                );
                context.SaveChanges();
            }
        
        }
    }
}
