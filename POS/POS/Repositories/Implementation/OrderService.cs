using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Data.Entities;
using POS.Models.DTO;
using POS.Repositories.Abstract;

namespace POS.Repositories.Implementation
{
    public class OrderService (DataContext dataContext): IOrderService
    {
        private readonly DataContext _dataContext=dataContext;

        public async Task<OrderDetailModel> OrderDetail(int id)
        {
            OrderDetailModel model = new OrderDetailModel();
            model.Order = _dataContext.Orders
             .Include(o => o.OrderDetails)
             .FirstOrDefault(o => o.Id == id);

            return model;
        }

        public async Task<OrderListing> OrderListing(DateTime selectedDate)
        {
            // Get today's date
            DateTime today = DateTime.Today;

            // Calculate Total Sell for today
            decimal totalSell = _dataContext.OrderDetails
                .Where(od => od.Orders.EnteredDate.Date == selectedDate.Date)
                .Sum(od => od.Quantity * od.UnitPrice);

            // Fetch orders for today and include order details
            List<Orders> orders = _dataContext.Orders
                .Where(o => o.EnteredDate.Date == selectedDate.Date)
                .Include(o => o.OrderDetails)
                .OrderBy(o => o.EnteredDate)
                .ToList();

            return new OrderListing()
            {
                TotalSellToday = totalSell,
                Orders = orders
            };
        }
    }
}
