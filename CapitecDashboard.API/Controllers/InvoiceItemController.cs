using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapitecDashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly InvoiceDbContext context;

        public InvoiceItemController(InvoiceDbContext context)
        {
            this.context = context;
        }

        [HttpGet("by-invoice")] 
        public async Task<IActionResult> GetByInvoice([FromQuery] string invoiceId)
        {
            var guid = Guid.Parse(invoiceId);
            var items = await context.InvoicesItem.AsNoTracking().Where(i => i.InvoiceId == guid).ToListAsync();
            return Ok(items);
        }

        [HttpGet("get-by-id")] 
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var entity = await context.InvoicesItem.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] InvoiceItem request)
        {
            request.Id = Guid.NewGuid().ToString();
            request.CreatedAt = DateTime.UtcNow;
            request.UpdatedAt = DateTime.UtcNow;
            request.Status = EntityStatus.Active;
            request.LineTotal = request.Quantity * request.UnitPrice;
            context.InvoicesItem.Add(request);
            await context.SaveChangesAsync();
            return Ok(request);
        }

        [HttpPost("update")] 
        public async Task<IActionResult> Update([FromBody] InvoiceItem request)
        {
            var entity = await context.InvoicesItem.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (entity == null) return NotFound();

            entity.Description = request.Description;
            entity.Quantity = request.Quantity;
            entity.UnitPrice = request.UnitPrice;
            entity.LineTotal = request.Quantity * request.UnitPrice;
            entity.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpDelete("delete")] 
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var entity = await context.InvoicesItem.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null) return NotFound();
            context.InvoicesItem.Remove(entity);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}


