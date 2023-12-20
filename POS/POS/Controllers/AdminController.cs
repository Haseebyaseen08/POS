using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Data.Entities;
using POS.Models.DTO;
using POS.Repositories.Abstract;

namespace POS.Controllers
{
    [Authorize(Roles = "Manager")]
    public class AdminController(IProductService productService, IOrderService orderService) : Controller
    {
        private readonly IProductService _productService = productService;
        private readonly IOrderService _orderService = orderService;

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel request)
        {
            var response = await _productService.Create(request);
            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductModel request)
        {
            var response = await _productService.Update(request);
            return Json(response);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var deleted = productService.Delete(id);

            if (deleted)
            {
                return Json(new { status = true, message = "Product deleted successfully" });
            }
            else
            {
                return Json(new { status = false, message = "Failed to delete product" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> OrderListing(DateTime? selectedDate)
        {
            DateTime dateToDisplay = selectedDate ?? DateTime.Today;

            ViewData["SelectedDate"] = dateToDisplay.Date;
            var orders = await _orderService.OrderListing(dateToDisplay);
            return View(orders);
        }

        public async Task<IActionResult> OrderDetail(int orderId)
        {
            var order = await _orderService.OrderDetail(orderId);

            return View(order);
        }

    }
}
