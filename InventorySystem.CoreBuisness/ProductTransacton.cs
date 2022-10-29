using System.ComponentModel.DataAnnotations;

namespace InventorySystem.CoreBuisness
{
    public class ProductTransacton
    {
        public int ProductTransactionId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int QuantityBefore { get; set; }
        [Required]
        public ProductTransactonType ActivityType { get; set; }
        [Required]
        public int QuantityAfter { get; set; }
        public string? ProductionNumber { get; set; }
        public string? SalesOrderNumber { get; set; }

        public double? UnitPrice { get; set; }

        [Required]
        public DateTime TransactionData { get; set; }
        [Required]
        public string DoneBy { get; set; }

        public Product Product { get; set; }

    }
}
