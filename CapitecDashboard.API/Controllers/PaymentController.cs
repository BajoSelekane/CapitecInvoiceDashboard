using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapitecDashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly InvoiceDbContext context;

        public PaymentController(InvoiceDbContext context)
        {
            this.context = context;
        }

        [HttpGet("by-invoice")] 
        public async Task<IActionResult> GetByInvoice([FromQuery] string invoiceId)
        {
            var guid = Guid.Parse(invoiceId);
            var items = await context.Payment.AsNoTracking().Where(i => i.InvoiceId == guid).ToListAsync();
            return Ok(items);
        }

        [HttpGet("get-by-id")] 
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var entity = await context.Payment.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Payment request)
        {
            request.Id = Guid.NewGuid().ToString();
            request.CreatedAt = DateTime.UtcNow;
            request.UpdatedAt = DateTime.UtcNow;
            request.Status = EntityStatus.Active;
            context.Payment.Add(request);
            await context.SaveChangesAsync();
            return Ok(request);
        }

        [HttpPost("update")] 
        public async Task<IActionResult> Update([FromBody] Payment request)
        {
            var entity = await context.Payment.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (entity == null) return NotFound();

            entity.Amount = request.Amount;
            entity.Method = request.Method;
            entity.Reference = request.Reference;
            entity.PaidAt = request.PaidAt;
            entity.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpDelete("delete")] 
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var entity = await context.Payment.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null) return NotFound();
            context.Payment.Remove(entity);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}


