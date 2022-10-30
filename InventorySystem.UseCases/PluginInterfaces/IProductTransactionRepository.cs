namespace InventorySystem.UseCases.PluginInterfaces
{
    public interface IProductTransactionRepository
    {
        Task ProduceAsync(string productNumber, Product product, int quantity, string doneBy);
    }
}