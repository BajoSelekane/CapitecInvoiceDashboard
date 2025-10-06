using CapitecDashboard.Presen.Services;
using Microsoft.AspNetCore.Mvc;
using CapitecDashboard.Presen.Filters;

namespace CapitecDashboard.Presen.Controllers
{
    [RequireLogin]
    public class InvoiceItemsController : Controller
    {
        private readonly ApiClient apiClient;
        public InvoiceItemsController(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<IActionResult> Index(string invoiceId)
        {
            var items = await apiClient.GetAsync<dynamic>($"api/InvoiceItem/by-invoice?invoiceId={invoiceId}");
            ViewBag.InvoiceId = invoiceId;
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string invoiceId, string description, decimal quantity, decimal unitPrice)
        {
            await apiClient.PostAsync<object>("api/InvoiceItem/create", new { InvoiceId = invoiceId, Description = description, Quantity = quantity, UnitPrice = unitPrice });
            return RedirectToAction(nameof(Index), new { invoiceId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string invoiceId, string id)
        {
            await apiClient.PostAsync<object>($"api/InvoiceItem/delete?id={id}", new { });
            return RedirectToAction(nameof(Index), new { invoiceId });
        }
    }
}


