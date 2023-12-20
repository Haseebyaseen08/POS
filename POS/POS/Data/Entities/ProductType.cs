using System.ComponentModel.DataAnnotations;

namespace POS.Data.Entities
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
