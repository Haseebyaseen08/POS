using System.ComponentModel.DataAnnotations;

namespace POS.Data.Entities
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public DateTime EnteredDate { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
