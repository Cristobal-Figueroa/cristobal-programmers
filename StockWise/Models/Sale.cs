using System.ComponentModel.DataAnnotations.Schema;

namespace StockWise.Models;

public class Sale
{
    public int Id { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    public List<SaleItem> Items { get; set; } = new();
}
