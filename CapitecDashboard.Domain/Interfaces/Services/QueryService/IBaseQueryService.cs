using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses.QueryResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Interfaces.Services.QueryService
{
    public interface IBaseQueryService<Fil, Ent> where Fil : BaseFilter where Ent : BaseEntity
    {
        RawObjectResponse<Ent> GetById(string id);
        RawObjectListResponse<Ent> Filter(Fil filter);
    }
}
