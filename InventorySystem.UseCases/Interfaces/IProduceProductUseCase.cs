namespace InventorySystem.UseCases.Interfaces
{
    public interface IProduceProductUseCase
    {
        Task ExecuteAsync(string productNumber, Product product, int quantity, double price, string doneBy);
    }
}