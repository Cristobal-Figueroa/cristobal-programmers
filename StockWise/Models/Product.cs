using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockWise.Models;

public class Product
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(18,2)"), Range(0, 999999)]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18,2)"), Range(0, 999999)]
    public decimal Cost { get; set; }

    [Range(0, 999999)]
    public int Stock { get; set; }

    [Range(0, 999999)]
    public int LowStockThreshold { get; set; } = 5;

    public bool IsLowStock => Stock <= LowStockThreshold;

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public List<SaleItem> SaleItems { get; set; } = new();
}
