using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Infrastructure.DbContexts;
using CapitecDashboard.Infrastructure.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CapitecDashboard.Infrastructure.Repositories
{
    public class InvoiceQueryRepository : QueryRepository<Invoice, InvoiceFilter>,
        IQueryRepository<Invoice, InvoiceFilter>
    {
        public InvoiceQueryRepository(InvoiceDbContext context) : base(context)
        {
        }

        protected override IQueryable<Invoice> FilterData(InvoiceFilter filter)
        {
           var data = context.Set<Invoice>()
                .Where(x=> x.Status ==EntityStatus.Active)
                .AsQueryable();
            if (filter.Id != null)
            
                data = data.Where(x=> x.Id == filter.Id);

                return data;     
        }

        protected override Invoice Get(string id)
        {
            var entity = context.Set<Invoice>()
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id && x.Status == EntityStatus.Active);

            return entity;
        }
        protected override IQueryable<Invoice> SpecifyInclude(IQueryable<Invoice> query)
        {

            query = query
                .Include(x => x.Id);

            return query;
        }
    }
}
