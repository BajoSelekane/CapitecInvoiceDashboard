using CapitecDashboard.Presen.Models;
using CapitecDashboard.Presen.Services;
using Microsoft.AspNetCore.Mvc;

namespace CapitecDashboard.Presen.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiClient apiClient;

        public AccountController(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await apiClient.PostAsync<dynamic>("api/account/login", new
            {
                Username = model.Username,
                Password = model.Password
            });

            if (response == null || response.codeStatus != 1)
            {
                model.Error = "Login failed";
                return View(model);
            }

            var token = (string?)response?.data?.token;
            if (!string.IsNullOrEmpty(token))
            {
                HttpContext.Session.SetString("jwt", token);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}


