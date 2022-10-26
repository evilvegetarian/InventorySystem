using InventorySystem.UseCases;
using InventorySystem.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Plugins.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventorySystemContext db;

        public ProductRepository(InventorySystemContext db)
        {
            this.db = db;
        }

        public async Task<List<Product>> GetProductsByName(string name)
        {
            return await this.db.Products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrWhiteSpace(name)).ToListAsync();
        }
    }
}
