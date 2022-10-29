using InventorySystem.UseCases.Interfaces;
using InventorySystem.UseCases.PluginInterfaces;

namespace InventorySystem.UseCases.Products
{
    public class ViewProductByIdUseCase : IViewProductByIdUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductByIdUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> ExecuteAsync(int productId)
        {
            return await productRepository.GetProductsByIdAsync(productId);
        }
    }
}
