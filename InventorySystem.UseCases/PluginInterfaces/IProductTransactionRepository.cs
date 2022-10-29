namespace InventorySystem.UseCases.PluginInterfaces
{
    public interface IProductTransactionRepository
    {
        Task ProduceAsync(string productNumber, Product product, int quantity, double price, string doneBy);
    }
}