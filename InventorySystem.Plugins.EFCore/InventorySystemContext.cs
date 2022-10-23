using InventorySystem.CoreBuisness;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Plugins.EFCore
{
    public class InventorySystemContext : DbContext
    {
        public InventorySystemContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { InventoryId = 1, InventoryName = "Engine", Quantity = 1, Price = 1000 },
                new Inventory { InventoryId = 2, InventoryName = "Body", Quantity = 1, Price = 400 },
                new Inventory { InventoryId = 3, InventoryName = "Wheels", Quantity = 1, Price = 100 },
                new Inventory { InventoryId = 4, InventoryName = "Seats", Quantity = 5, Price = 50 }
                );
        }
    }
}
