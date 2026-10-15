using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockWise.Models;

namespace StockWise.Data;

/// <summary>
/// Seeds the database with sample categories, products, one demo sale,
/// and a demo user account so the app is usable right after deployment.
/// </summary>
public static class DbSeeder
{
    public const string DemoEmail = "admin@stockwise.dev";
    public const string DemoPassword = "Admin123!";

    public static async Task SeedAsync(IServiceProvider services)
    {
        var db = services.GetRequiredService<ApplicationDbContext>();
        await db.Database.MigrateAsync();

        // Demo user so reviewers can sign in without registering.
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        if (await userManager.FindByEmailAsync(DemoEmail) is null)
        {
            var user = new ApplicationUser { UserName = DemoEmail, Email = DemoEmail, EmailConfirmed = true };
            await userManager.CreateAsync(user, DemoPassword);
        }

        if (await db.Categories.AnyAsync()) return;

        var categories = new[]
        {
            new Category { Name = "Beverages" },
            new Category { Name = "Snacks" },
            new Category { Name = "Cleaning" },
            new Category { Name = "Personal Care" },
        };
        db.Categories.AddRange(categories);
        await db.SaveChangesAsync();

        var products = new[]
        {
            new Product { Name = "Coca-Cola 1.5L", Price = 2500, Cost = 1500, Stock = 24, LowStockThreshold = 6, CategoryId = categories[0].Id },
            new Product { Name = "Sprite 500ml", Price = 1200, Cost = 700, Stock = 30, LowStockThreshold = 8, CategoryId = categories[0].Id },
            new Product { Name = "Coffee Nescafe 170g", Price = 6990, Cost = 4500, Stock = 12, LowStockThreshold = 4, CategoryId = categories[0].Id },
            new Product { Name = "Potato Chips 150g", Price = 1990, Cost = 1100, Stock = 40, LowStockThreshold = 10, CategoryId = categories[1].Id },
            new Product { Name = "Chocolate Bar 100g", Price = 1490, Cost = 800, Stock = 3, LowStockThreshold = 5, CategoryId = categories[1].Id },
            new Product { Name = "Salted Peanuts 200g", Price = 2290, Cost = 1300, Stock = 18, LowStockThreshold = 5, CategoryId = categories[1].Id },
            new Product { Name = "Dish Soap 750ml", Price = 2890, Cost = 1700, Stock = 15, LowStockThreshold = 4, CategoryId = categories[2].Id },
            new Product { Name = "Laundry Detergent 1kg", Price = 5990, Cost = 3800, Stock = 2, LowStockThreshold = 4, CategoryId = categories[2].Id },
            new Product { Name = "Shampoo 400ml", Price = 3990, Cost = 2400, Stock = 10, LowStockThreshold = 3, CategoryId = categories[3].Id },
            new Product { Name = "Toothpaste 90g", Price = 2190, Cost = 1200, Stock = 22, LowStockThreshold = 6, CategoryId = categories[3].Id },
        };
        db.Products.AddRange(products);
        await db.SaveChangesAsync();

        // One demo sale so the history and dashboard are not empty.
        var sale = new Sale
        {
            Date = DateTime.Now.AddHours(-3),
            Items = new List<SaleItem>
            {
                new() { ProductId = products[0].Id, Quantity = 2, UnitPrice = products[0].Price },
                new() { ProductId = products[3].Id, Quantity = 1, UnitPrice = products[3].Price },
            }
        };
        sale.Total = sale.Items.Sum(i => i.LineTotal);
        products[0].Stock -= 2;
        products[3].Stock -= 1;
        db.Sales.Add(sale);
        await db.SaveChangesAsync();
    }
}
