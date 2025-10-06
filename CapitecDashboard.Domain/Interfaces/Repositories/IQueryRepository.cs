using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Request.Filters;


namespace CapitecDashboard.Domain.Interfaces.Repositories
{
    public interface IQueryRepository<Ent, Fil> where Ent : BaseEntity where Fil : BaseFilter
    {

        IQueryable<Ent> Filter(Fil filter);
        Ent GetById(string id);
        IQueryable<Ent> GetAll();
    }
}
