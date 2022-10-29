using InventorySystem.CoreBuisness;

namespace InventorySystem.UseCases.PluginInterfaces
{
    public interface IInventoryTransactonRepository
    {
        Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, double price, string doneBy);
    }
}