using System.ComponentModel.DataAnnotations;

namespace InventorySystem.WebApp.ViewModels
{
    public class PurchaseViewModel
    {
        [Required]
        public string PurchaseOrder { get; set; } = string.Empty;

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "You have to select a product.")]
        public int InventoryId { get; set; }

        [Required]
        public string InventoryName { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity has to be greater than 1.")]
        public int QuantityToPurchase { get; set; }

        public double InventoryPrice { get; set; }

    }
}
