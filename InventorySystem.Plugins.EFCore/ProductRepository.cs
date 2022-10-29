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

        public async Task AddProductAsync(Product product)
        {
            if (db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
                return;

            db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await db.Products.FindAsync(productId);
            if (product != null)
            {
                product.IsActive = false;
                await db.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductsByIdAsync(int productId)
        {
            return await db.Products
                           .Include(x => x.ProductInventories)
                           .ThenInclude(x => x.Inventory)
                           .FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task<List<Product>> GetProductsByNameAsync(string name)
        {
            return await this.db.Products
                .Where(x => (x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                   string.IsNullOrWhiteSpace(name)) && x.IsActive).ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
                return;
            var prod = await db.Products.FindAsync(product.ProductId);
            if (prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.Quantity = product.Quantity;
                prod.Price = product.Price;
                prod.ProductInventories = product.ProductInventories;

                await db.SaveChangesAsync();
            }
        }
    }
}
