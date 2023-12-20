using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Repositories.Abstract;

namespace POS.Controllers
{
    [Authorize]
    public class DashboardController(IProductService productService) : Controller
    {
        private readonly IProductService _productService=productService;
        public async Task<IActionResult> Index()
        {
            var response = await _productService.Products();
            return View(response);
        }
       
    }
}
