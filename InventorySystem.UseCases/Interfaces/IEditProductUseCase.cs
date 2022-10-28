namespace InventorySystem.UseCases.Interfaces
{
    public interface IEditProductUseCase
    {
        Task ExecutAsync(Product product);
    }
}