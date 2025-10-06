using CapitecDashboard.Domain.Interfaces.Services.CommandService;
using CapitecDashboard.Domain.Interfaces.Services.QueryService;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Services.CommandServices;
using CapitecDashboard.Domain.Services.QueryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitecDashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceCommandService _invoiceCommandService;
        private readonly IInvoiceQueryService _invoiceQueryService;

        public InvoiceController(IInvoiceCommandService invoiceCommandService, IInvoiceQueryService invoiceQueryService)
        {
            _invoiceCommandService = invoiceCommandService;
            _invoiceQueryService = invoiceQueryService;
        }

        [HttpPost("Create-Invoice")]
        public IActionResult Create([FromBody] InvoiceRequest request)
        {
            var inv = _invoiceCommandService.Add(request);
            return Ok(inv);
        }
        [HttpDelete("Delete-Invoice")]
        public IActionResult Delete([FromBody] BaseRequest request) 
        {
            var res =_invoiceCommandService.Delete(request);
            return Ok(res);
        }

        [HttpPost("Update-Invoice")]
        public IActionResult Update([FromBody] InvoiceRequest request)
        {
            var res = _invoiceCommandService.Update(request);
            return Ok(res);
        }

    }
}