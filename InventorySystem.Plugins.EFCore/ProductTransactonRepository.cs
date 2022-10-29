using InventorySystem.CoreBuisness;
using InventorySystem.UseCases;
using InventorySystem.UseCases.PluginInterfaces;

namespace InventorySystem.Plugins.EFCore
{
    public class ProductTransactonRepository : IProductTransactionRepository
    {
        private readonly InventorySystemContext db;
        private readonly IProductRepository productRepository;

        public ProductTransactonRepository(InventorySystemContext db, IProductRepository productRepository)
        {
            this.db = db;
            this.productRepository = productRepository;
        }
        public async Task ProduceAsync(string productNumber, Product product, int quantity, double price, string doneBy)
        {
            var prod = this.productRepository.GetProductsByIdAsync(product.ProductId);

            if (prod != null)
            {
                foreach (var pi in prod.ProductInventories)
                {
                    pi.Inventory.Quantity -= quantity * pi.InventoryQuantity;
                }
            }

            this.db.ProductTransactons.Add(new ProductTransacton
            {
                ProductionNumber = productNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactonType.ProduceProduct,
                QuantityAfter = product.Quantity + quantity,
                TransactionData = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price

            });
            await this.db.SaveChangesAsync();
        }
    }
}
