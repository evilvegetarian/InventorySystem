using InventorySystem.CoreBuisness;
using InventorySystem.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventorySystemContext db;

        public InventoryRepository(InventorySystemContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            return await this.db.Inventories.Where(x => x.InventoryName.
            Contains(name,StringComparison.OrdinalIgnoreCase) ||
                                          string.IsNullOrWhiteSpace(name)).ToListAsync();
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            this.db.Inventories.Add(inventory);
            await this.db.SaveChangesAsync();
        }
    }
}