using System.ComponentModel.DataAnnotations;

namespace InventorySystem.CoreBuisness
{
    public class InventoryTransacton
    {
        public int InventoryTransactionId { get; set; }
        [Required]
        public int InventoryId { get; set; }
        [Required]
        public int QuantityBefore { get; set; }
        [Required] 
        public InventoryTransactonType InventoryType { get; set; }
        [Required]
        public int QuantityAfter { get; set; }   
        public string? PONumber { get; set; }
        public string? ProductionNumber { get; set; }

        public double? Cost { get; set; }

        [Required]
        public DateTime TransactionData { get; set; }
        [Required]
        public string DoneBy { get; set; }

        public Inventory Inventory { get; set; }

    }
}
