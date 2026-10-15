using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockWise.Models;

public class SaleItem
{
    public int Id { get; set; }

    public int SaleId { get; set; }
    public Sale? Sale { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    [Range(1, 999999)]
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)"), Range(0, 999999)]
    public decimal UnitPrice { get; set; }

    [NotMapped]
    public decimal LineTotal => Quantity * UnitPrice;
}
