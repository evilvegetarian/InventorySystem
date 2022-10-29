﻿using InventorySystem.UseCases;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.CoreBuisness
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        [Required]
        public string? InventoryName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to {0}")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater or equal to {0}")]
        public double Price { get; set; }

        public List<ProductInventory>? ProductInventories { get; set; }
    }
}
