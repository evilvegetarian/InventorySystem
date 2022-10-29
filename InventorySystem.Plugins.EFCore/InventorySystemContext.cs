using InventorySystem.CoreBuisness;
using InventorySystem.UseCases;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Plugins.EFCore
{
    public class InventorySystemContext : DbContext
    {
        public InventorySystemContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet <InventoryTransacton> InventoryTransactons { get; set; } 
        public DbSet<ProductTransacton> ProductTransactons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInventory>()
                        .HasKey(pi => new { pi.ProductId, pi.InventoryId });

            modelBuilder.Entity<ProductInventory>()
                        .HasOne(pi => pi.Product)
                        .WithMany(p => p.ProductInventories)
                        .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductInventory>()
                        .HasOne(pi => pi.Inventory)
                        .WithMany(i => i.ProductInventories)
                        .HasForeignKey(pi => pi.InventoryId);

            modelBuilder.Entity<Inventory>().HasData(
               new Inventory { InventoryId = 1, InventoryName = "Gas Engine", Quantity = 1, Price = 1000 },
               new Inventory { InventoryId = 2, InventoryName = "Body", Quantity = 1, Price = 400 },
               new Inventory { InventoryId = 3, InventoryName = "Wheels", Quantity = 1, Price = 100 },
               new Inventory { InventoryId = 4, InventoryName = "Seats", Quantity = 5, Price = 50 },
               new Inventory { InventoryId = 5, InventoryName = "Electric Engine", Quantity = 2, Price = 800 },
               new Inventory { InventoryId = 6, InventoryName = "Battery", Quantity = 5, Price = 400 }
               );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Gas Car", Quantity = 1, Price = 20000 },
                new Product { ProductId = 2, ProductName = "Electric Car", Quantity = 1, Price = 15000 }
                );

            modelBuilder.Entity<ProductInventory>().HasData(
                new ProductInventory { ProductId = 1, InventoryId = 1, InventoryQuantity = 1 },
                new ProductInventory { ProductId = 1, InventoryId = 2, InventoryQuantity = 1 },
                new ProductInventory { ProductId = 1, InventoryId = 3, InventoryQuantity = 4 },
                new ProductInventory { ProductId = 1, InventoryId = 4, InventoryQuantity = 5 }
                );

            modelBuilder.Entity<Product>().HasData(
                new ProductInventory { ProductId = 2, InventoryId = 5, InventoryQuantity = 1 },
                new ProductInventory { ProductId = 2, InventoryId = 2, InventoryQuantity = 1 },
                new ProductInventory { ProductId = 2, InventoryId = 3, InventoryQuantity = 4 },
                new ProductInventory { ProductId = 2, InventoryId = 4, InventoryQuantity = 5 },
                new ProductInventory { ProductId = 2, InventoryId = 6, InventoryQuantity = 1 }
                );

        }
    }
}
