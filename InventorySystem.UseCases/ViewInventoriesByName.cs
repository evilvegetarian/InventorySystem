using InventorySystem.CoreBuisness;
using InventorySystem.UseCases.PluginInterfaces;

namespace InventorySystem.UseCases
{
    public class ViewInventoriesByName
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoriesByName(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name)
        {

        }
    }
}
