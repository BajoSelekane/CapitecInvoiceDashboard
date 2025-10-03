using CapitecDashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Interfaces.Repositories
{
    public interface ICommandRepository<Ent> where Ent : BaseEntity
    {
        Ent Create(Ent entity);
        void Create(List<Ent> entities);
        Ent GetById(string id);
        bool Delete(string id, bool isPermanetDelete = false);
        bool Delete(Ent entity, bool isPermanetDelete = false);
        Ent Update(Ent entity);
    }
}
