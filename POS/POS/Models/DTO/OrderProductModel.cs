namespace POS.Models.DTO
{
    public class OrderProductModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public decimal? UnitPrice { get; set; }
    }

    public class OrderModel
    {
        public int OrderId { get; set; }
        public List<OrderProductModel> OrderProduct { get; set; }
    }
}
