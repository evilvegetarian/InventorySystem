using InventorySystem.CoreBuisness;
using InventorySystem.Plugins.EFCore;

namespace InventorySystem.UseCases.PluginInterfaces
{
    public class InventoryTransactonRepository : IInventoryTransactonRepository
    {
        private readonly InventorySystemContext db;

        public InventoryTransactonRepository(InventorySystemContext db)
        {
            this.db = db;
        }

        public async Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, double price, string doneBy)
        {
            this.db.InventoryTransactons.Add(new InventoryTransacton
            {
                PONumber = poNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactonType.PurchaseInventory,
                QuantityAfter = inventory.Quantity + quantity,
                TransactionData = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });
            await this.db.SaveChangesAsync();
        }
    }
}