using POS.Models.DTO;

namespace POS.Repositories.Abstract
{
    public interface IOrderService
    {
        Task<OrderListing> OrderListing(DateTime selectedDate);
        Task<OrderDetailModel> OrderDetail(int id);
    }
}
