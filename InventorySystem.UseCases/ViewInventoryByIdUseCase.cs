using InventorySystem.CoreBuisness;
using InventorySystem.UseCases.Interfaces;
using InventorySystem.UseCases.PluginInterfaces;

namespace InventorySystem.UseCases
{
    public class ViewInventoryByIdUseCase : IViewInventoryByIdUseCase
    {
        private readonly IInventoryRepository inventoryRepository;

        public ViewInventoryByIdUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task<Inventory?> ExecuteAsync(int inventoryId)
        {
            return await this.inventoryRepository.GetInventoryByIdAsync(inventoryId);
        }
    }
}
