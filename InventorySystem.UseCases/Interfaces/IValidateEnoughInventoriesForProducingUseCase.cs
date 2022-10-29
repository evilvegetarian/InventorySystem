namespace InventorySystem.UseCases.Interfaces
{
    public interface IValidateEnoughInventoriesForProducingUseCase
    {
        Task<bool> ExecuteAsync(Product product, int quantity);
    }
}