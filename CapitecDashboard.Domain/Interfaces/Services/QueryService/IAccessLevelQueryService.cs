using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Models.Responses.QueryResponse.AccessLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Interfaces.Services.QueryService
{
    public interface IAccessLevelQueryService : IBaseQueryService<AccessLevelFilter, AccessLevel>
    {
        ObjectListResponse<AccessLevelListResponse> Filter(AccessLevelFilter filter);
        ObjectResponse<AccessLevelListResponse> Get(string id);
    }
}
