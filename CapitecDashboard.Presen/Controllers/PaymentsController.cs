using CapitecDashboard.Presen.Services;
using Microsoft.AspNetCore.Mvc;
using CapitecDashboard.Presen.Filters;

namespace CapitecDashboard.Presen.Controllers
{
    [RequireLogin]
    public class PaymentsController : Controller
    {
        private readonly ApiClient apiClient;
        public PaymentsController(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IActionResult> Index(string invoiceId)
        {
            var items = await apiClient.GetAsync<dynamic>($"api/Payment/by-invoice?invoiceId={invoiceId}");
            ViewBag.InvoiceId = invoiceId;
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string invoiceId, decimal amount, string? method, string? reference)
        {
            await apiClient.PostAsync<object>("api/Payment/create", new { InvoiceId = invoiceId, Amount = amount, Method = method, Reference = reference });
            return RedirectToAction(nameof(Index), new { invoiceId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string invoiceId, string id)
        {
            await apiClient.PostAsync<object>($"api/Payment/delete?id={id}", new { });
            return RedirectToAction(nameof(Index), new { invoiceId });
        }
    }
}


