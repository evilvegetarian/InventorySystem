namespace InventorySystem.UseCases.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<Product> ExecuteAsync(int productId);
    }
}