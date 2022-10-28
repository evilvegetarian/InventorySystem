using InventorySystem.UseCases;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.CoreBuisness.Validations
{
    public class Product_EnsurePriceIsGreaterThanInventoriesPrice : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;
            if (product != null)
            {
                if (!product.ValidatePricing())
                    return new ValidationResult($"the product's price is less than tht summary of this its inventorie's price:{product.TotalInventoryCost()}");
            }

            return ValidationResult.Success;
        }
    }
}
