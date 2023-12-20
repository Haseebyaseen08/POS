using System.ComponentModel.DataAnnotations;

namespace POS.Data.Entities
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        public Orders Orders { get; set; }
    }
}
