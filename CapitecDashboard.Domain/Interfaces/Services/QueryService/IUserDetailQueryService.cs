using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Interfaces.Services.QueryService;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Models.Responses.UserDetail;


//using CapitecDashboard.Domain.Models.Responses.QueryResponse.SubDistrict;
using ChwpDashboard.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CapitecDashboard.Domain.Models.Responses.QueryResponse.UserDetail;

namespace CapitecDashboard.Domain.Interfaces.Services.QueryService
{
    public interface IUserDetailQueryService : IBaseQueryService<UserDetailFilter, UserDetail>
    {
        ObjectListResponse<UserDetailListResponse> Filter(UserDetailFilter filter);
        ObjectResponse<UserDetailResponse> Get(string id);
    }
}
