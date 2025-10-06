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

namespace CapitecDashboard.Infrastructure.Repositories
{
    public class AccessLevelQueryRepository : QueryRepository<AccessLevel, AccessLevelFilter>,
         IQueryRepository<AccessLevel, AccessLevelFilter>

    {
        public AccessLevelQueryRepository(InvoiceDbContext context) : base(context)
        {

        }

        protected override IQueryable<AccessLevel> FilterData(AccessLevelFilter filter)
        {
            var data = context.Set<AccessLevel>()
              .Where(x => x.Status == EntityStatus.Active)
              .AsQueryable();

            if (filter.Id != null)
                data = data.Where(x => x.Id == filter.Id);

            return data;
        }

        protected override AccessLevel Get(string id)
        {
            var entity = context.Set<AccessLevel>()
              .AsNoTracking()
              .FirstOrDefault(x => x.Id == id && x.Status == EntityStatus.Active);
            return entity;
        }

        IQueryable<AccessLevel> IQueryRepository<AccessLevel, AccessLevelFilter>.Filter(AccessLevelFilter filter)
        {
            throw new NotImplementedException();
        }

        //IQueryable<AccessLevel> IQueryRepository<AccessLevel, AccessLevelFilter>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        AccessLevel IQueryRepository<AccessLevel, AccessLevelFilter>.GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
