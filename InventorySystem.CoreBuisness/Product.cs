using InventorySystem.CoreBuisness.Validations;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.UseCases
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to {0}")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater or equal to {0}")]
        [Product_EnsurePriceIsGreaterThanInventoriesPrice]
        public double Price { get; set; }

        public List<ProductInventory>? ProductInventories { get; set; }

        public double TotalInventoryCost()
        {
            return this.ProductInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);

        }

        public bool ValidatePricing()
        {
            if (ProductInventories == null || ProductInventories.Count <= 0)
                return true;


            if (this.TotalInventoryCost() > Price)
                return false;

            return true;
        }
    }
}