using CapitecDashboard.Presen.Models;
using CapitecDashboard.Presen.Services;
using Microsoft.AspNetCore.Mvc;
using CapitecDashboard.Presen.Filters;

namespace CapitecDashboard.Presen.Controllers
{
    [RequireLogin]
    public class InvoicesController : Controller
    {
        private readonly ApiClient apiClient;

        public InvoicesController(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var res = await apiClient.GetAsync<dynamic>("api/Invoice/Filter");
            return View(res);
        }

        public async Task<IActionResult> Details(string id)
        {
            var res = await apiClient.GetAsync<dynamic>($"api/Invoice/Get-By-Id?id={id}");
            return View(res);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new InvoiceEditModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceEditModel model)
        {
            var res = await apiClient.PostAsync<object>("api/Invoice/Create-Invoice", new { CustomerId = model.CustomerId, UserId = "system" });
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var res = await apiClient.GetAsync<dynamic>($"api/Invoice/Get-By-Id?id={id}");
            return View(new InvoiceEditModel { Id = id, CustomerId = res?.customerId });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InvoiceEditModel model)
        {
            await apiClient.PostAsync<object>("api/Invoice/Update-Invoice", new { Id = model.Id, CustomerId = model.CustomerId, UserId = "system" });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await apiClient.PostAsync<object>("api/Invoice/Delete-Invoice", new { Id = id, UserId = "system" });
            return RedirectToAction(nameof(Index));
        }
    }
}


