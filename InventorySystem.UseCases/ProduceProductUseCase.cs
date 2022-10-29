using InventorySystem.UseCases.Interfaces;
using InventorySystem.UseCases.PluginInterfaces;

namespace InventorySystem.UseCases
{
    public class ProduceProductUseCase : IProduceProductUseCase
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly IProductRepository productRepository;
        private readonly IInventoryTransactonRepository inventoryTransactonRepository;
        private readonly IProductTransactionRepository productTransactionRepository;

        public ProduceProductUseCase(
            IInventoryRepository inventoryRepository,
            IProductRepository productRepository,
            IInventoryTransactonRepository inventoryTransactonRepository,
            IProductTransactionRepository productTransactionRepository)
        {
            this.inventoryRepository = inventoryRepository;
            this.productRepository = productRepository;
            this.inventoryTransactonRepository = inventoryTransactonRepository;
            this.productTransactionRepository = productTransactionRepository;
        }


        public async Task ExecuteAsync(string productNumber, Product product, int quantity, double price, string doneBy)
        {
            await this.productTransactionRepository.ProduceAsync(productNumber, product, quantity, price, doneBy);

            product.Quantity += quantity;
            await this.productRepository.UpdateProductAsync(product);
        }
    }
}
