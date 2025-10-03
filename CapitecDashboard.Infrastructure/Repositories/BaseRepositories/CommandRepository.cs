using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Infrastructure.Repositories.BaseRepositories
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        protected readonly InvoiceDbContext context;
        public CommandRepository(InvoiceDbContext context)
        {
            this.context = context;
        }


        public T Create(T entity)
        {
            entity.Status = EntityStatus.Active;
            entity.CreatedAt = DateTime.Now;
            entity.CreatedAt = DateTime.Now;
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Create(List<T> entities)
        {
            //entity.Status = EntityStatus.Active;
            //entity.CreatedAt = DateTime.Now;
            entities
                .Select(e => {
                    e.CreatedAt = DateTime.Now;
                    e.Status = EntityStatus.Active; return e;
                })
                .ToList();

            context.Set<T>().AddRange(entities);
            context.SaveChanges();
        }

        public bool Delete(string id, bool isPermanetDelete = false)
        {
            var entity = context.Set<T>().AsNoTracking()
                    .FirstOrDefault(e => e.Id == id);

            if (entity == null)
                return false;

            entity.UpdatedAt = DateTime.Now;
            entity.Status = EntityStatus.Deleted;

            if (isPermanetDelete)
            {
                context.Set<T>()
                .Remove(entity);
            }

            context.SaveChanges();

            return entity.Status == EntityStatus.Deleted;
        }

        public bool Delete(T entity, bool isPermanetDelete = false)
        {
            entity.Status = EntityStatus.Deleted;
            entity.UpdatedAt = DateTime.Now;

            if (isPermanetDelete)
            {
                var res = context.Set<T>()

                .Remove(entity);
            }

            context.SaveChanges();
            return true;
        }

        public T GetById(string id)
        {
            var entity = context.Set<T>()
                .AsNoTracking()
                .Where(e => e.Status == EntityStatus.Active)
                .FirstOrDefault(e => e.Id == id);

            return entity;
        }

        public IQueryable<T> GetAll()
        {
            var items = context.Set<T>()
                    .AsNoTracking()
                    .AsQueryable();

            return items;
        }

        public T Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            var item = context.Update(entity);

            context.Entry(entity).Property(x => x.CreatedAt).IsModified = false;
            context.SaveChanges();

            return item.State != EntityState.Unchanged ?
                null : item.Entity;
        }
    }
}
