using InventorySystem.CoreBuisness;

namespace InventorySystem.UseCases.Interfaces
{
    public interface IPurchaseInventoryUseCase
    {
        Task ExecuteAsync(string poNumber, Inventory inventory, int quantity, string doneBy);
    }
}