using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using POS.Models;
using System.Diagnostics;

namespace POS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Error = this.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error });
        }
    }
}
