using InventorySystem.CoreBuisness;
using InventorySystem.UseCases.Interfaces;
using InventorySystem.UseCases.PluginInterfaces;

namespace InventorySystem.UseCases
{
    public class PurchaseInventoryUseCase : IPurchaseInventoryUseCase
    {
        private readonly IInventoryTransactonRepository inventoryTransactonRepository;

        public PurchaseInventoryUseCase(
            IInventoryTransactonRepository inventoryTransactonRepository,
            IInventoryRepository inventoryRepository)
        {
            this.inventoryTransactonRepository = inventoryTransactonRepository;
            InventoryRepository = inventoryRepository;
        }

        public IInventoryRepository InventoryRepository { get; }

        public async Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy)
        {
            await this.inventoryTransactonRepository.PurchaseAsync(poNumber, inventory, quantity, inventory.Price, doneBy);
             inventory.Quantity += quantity;

            await this.InventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
