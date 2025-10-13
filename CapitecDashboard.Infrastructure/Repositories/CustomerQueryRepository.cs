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
    public class CustomerQueryRepository : QueryRepository<Customer, CustomerFilter>,
        IQueryRepository<Customer, CustomerFilter>
    {
        public CustomerQueryRepository(InvoiceDbContext context) : base(context)
        {
        }

        protected override IQueryable<Customer> FilterData(CustomerFilter filter)
        {
            var data = context.Set<Customer>()
               .Where(x => x.Status == EntityStatus.Active)
               .AsQueryable();
            if (filter.Id != null)
                data = data.Where(x => x.Id == filter.Id);

            return data;
        }

        protected override Customer Get(string id)
        {
            var entity = context.Set<Customer>()
               .AsNoTracking()
               .FirstOrDefault(x => x.Id == id && x.Status == EntityStatus.Active);

            return entity;
        }
    }
}
