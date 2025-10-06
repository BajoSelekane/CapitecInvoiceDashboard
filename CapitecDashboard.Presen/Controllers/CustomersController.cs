using CapitecDashboard.Presen.Services;
using Microsoft.AspNetCore.Mvc;
using CapitecDashboard.Presen.Filters;

namespace CapitecDashboard.Presen.Controllers
{
    [RequireLogin]
    public class CustomersController : Controller
    {
        private readonly ApiClient apiClient;

        public CustomersController(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var items = await apiClient.GetAsync<dynamic>("api/Customer/filter");
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(string id, int status)
        {
            await apiClient.PostAsync<object>($"api/Customer/update-status?id={id}&status={status}", new { });
            return RedirectToAction(nameof(Index));
        }
    }
}


