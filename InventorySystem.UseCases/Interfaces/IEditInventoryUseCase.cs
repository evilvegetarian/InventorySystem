using InventorySystem.CoreBuisness;

namespace InventorySystem.UseCases.Interfaces
{
    public interface IEditInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}