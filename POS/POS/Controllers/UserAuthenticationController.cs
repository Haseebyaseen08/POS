using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Models.DTO;
using POS.Repositories.Abstract;

namespace POS.Controllers
{
    public class UserAuthenticationController(IUserAuthenticationService userAuthenticationService) : Controller
    {
        private readonly IUserAuthenticationService _userAuthenticationService=userAuthenticationService;
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Login request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = await _userAuthenticationService.Login(request);

            if (response.StatusCode == 200)
            {
                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                TempData["message"] = response.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Registration(Registration request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = await _userAuthenticationService.Register(request);

            TempData["message"] = response.Message;
            return RedirectToAction(nameof(Registration));
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _userAuthenticationService.Logout();
            return RedirectToAction(nameof(Login));
        }
    }
}
