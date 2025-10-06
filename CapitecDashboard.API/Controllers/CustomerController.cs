using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapitecDashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly InvoiceDbContext context;

        public CustomerController(InvoiceDbContext context)
        {
            this.context = context;
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] CustomerFilter filter)
        {
            var query = context.Customers.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(filter.Id))
                query = query.Where(c => c.Id == filter.Id);

            var items = await query.ToListAsync();
            return Ok(items);
        }

        [HttpGet("get-by-id")] 
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var entity = await context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Customer request)
        {
            request.Id = Guid.NewGuid().ToString();
            request.CreatedAt = DateTime.UtcNow;
            request.UpdatedAt = DateTime.UtcNow;
            request.Status = EntityStatus.Active;
            context.Customers.Add(request);
            await context.SaveChangesAsync();
            return Ok(request);
        }

        [HttpPost("update")] 
        public async Task<IActionResult> Update([FromBody] Customer request)
        {
            var entity = await context.Customers.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (entity == null) return NotFound();

            entity.CustomerName = request.CustomerName;
            entity.Email = request.Email;
            entity.Phone = request.Phone;
            entity.Address = request.Address;
            entity.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpPost("update-status")] 
        public async Task<IActionResult> UpdateStatus([FromQuery] string id, [FromQuery] EntityStatus status)
        {
            var entity = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null) return NotFound();
            entity.Status = status;
            entity.UpdatedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpDelete("delete")] 
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var entity = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null) return NotFound();
            context.Customers.Remove(entity);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}


