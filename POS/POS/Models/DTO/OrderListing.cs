using POS.Data.Entities;

namespace POS.Models.DTO
{
    public class OrderListing
    {
        public decimal TotalSellToday { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
