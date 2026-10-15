using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockWise.Models;

namespace StockWise.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    /// <summary>Products in the inventory catalog.</summary>
    public DbSet<Product> Products => Set<Product>();

    /// <summary>Categories used to organize products.</summary>
    public DbSet<Category> Categories => Set<Category>();

    /// <summary>Registered sales (one header per transaction).</summary>
    public DbSet<Sale> Sales => Set<Sale>();

    /// <summary>Line items of each sale, with the unit price snapshot.</summary>
    public DbSet<SaleItem> SaleItems => Set<SaleItem>();
}
