using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Models.DTO;
using POS.Repositories.Abstract;

namespace POS.Controllers
{
    [Authorize]
    public class BillingController(IProductService productService) : Controller
    {
        private readonly IProductService _productService = productService;
        public async Task<IActionResult> Index()
        {
            var response = await _productService.Products();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessOrder(List<OrderProductModel> selectedProducts)
        {
            var response = await _productService.Bill(selectedProducts);
            decimal total = 0;
            foreach(var product in response.OrderProduct)
            {
                total = total + (product.UnitPrice??0) * product.Quantity;
            }

            //TempData["Bill"] = total;

            return PartialView("_ReceiptPartial", new BillingDTO { Products=response.OrderProduct, Bill=total, OrderId=response.OrderId});
        }
    }
}
