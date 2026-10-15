using Microsoft.EntityFrameworkCore;
using StockWise.Models;

namespace StockWise.Data;

public class StockWiseContext : DbContext
{
    public StockWiseContext(DbContextOptions<StockWiseContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleItem> SaleItems => Set<SaleItem>();
}
