using InventorySystem.UseCases.PluginInterfaces;

namespace InventorySystem.UseCases
{
    public class DeleteProductUseCase
    {
        private readonly IProductRepository productRepository;

        public DeleteProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task ExecuteAsync(int productId)
        {
           await this.productRepository.DeleteProductAsync(productId);
        }
    }
}
