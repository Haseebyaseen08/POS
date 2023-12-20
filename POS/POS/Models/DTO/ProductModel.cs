using System.ComponentModel.DataAnnotations;

namespace POS.Models.DTO
{
    public enum ProductType
    {
        Food=1,
        Beverages,
        Sauce
    }
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please select a product type")]
        public ProductType ProductType { get; set; }

    }
}
