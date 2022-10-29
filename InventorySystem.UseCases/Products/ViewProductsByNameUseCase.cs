using InventorySystem.UseCases.Interfaces;
using InventorySystem.UseCases.PluginInterfaces;

namespace InventorySystem.UseCases.Products
{
    public class ViewProductsByNameUseCase : IViewProductsByNameUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductsByNameUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<List<Product>> ExecuteAsync(string name = "")
        {
            return await productRepository.GetProductsByNameAsync(name);
        }
    }
}
