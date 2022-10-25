using InventorySystem.CoreBuisness;

namespace InventorySystem.UseCases.Interfaces
{
    public interface IViewInventoryByIdUseCase
    {
        Task<Inventory?> ExecuteAsync(int inventoryId);
    }
}