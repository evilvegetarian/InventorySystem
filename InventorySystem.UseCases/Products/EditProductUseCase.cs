using InventorySystem.UseCases.Interfaces;
using InventorySystem.UseCases.PluginInterfaces;

namespace InventorySystem.UseCases.Products
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository productRepository;

        public EditProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task ExecutAsync(Product product)
        {
            await productRepository.UpdateProductAsync(product);
        }
    }
}
