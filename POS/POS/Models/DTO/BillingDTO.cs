namespace POS.Models.DTO
{
    public class BillingDTO
    {
        public List<OrderProductModel> Products { get; set; } = new List<OrderProductModel>();
        public decimal Bill { get; set; }
        public int OrderId { get; set; }
    }
}
