using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Models.Responses.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Interfaces.Services.QueryService
{
    public interface IUserDetailQueryService : IBaseQueryService<UserDetailFilter, UserDetail>
    {
        ObjectListResponse<UserDetailListResponse> Filter(UserDetailFilter filter);
        ObjectResponse<UserDetailResponse> Get(string id);
    }
}
