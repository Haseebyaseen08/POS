using System.ComponentModel.DataAnnotations;

namespace POS.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductTypeId { get; set; }
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
    }
}
