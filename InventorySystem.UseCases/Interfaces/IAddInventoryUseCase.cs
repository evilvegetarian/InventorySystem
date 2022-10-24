using InventorySystem.CoreBuisness;

namespace InventorySystem.UseCases.Interfaces
{
    public interface IAddInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}