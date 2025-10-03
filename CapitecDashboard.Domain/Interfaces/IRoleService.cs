using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Interfaces
{
    public interface IRoleService
    {
        ObjectListResponse<RoleResponse> Filter(RoleFilter filter);

        ObjectListResponse<RoleResponse> GetRoleByProgramDataId(RoleFilter filter);
        Task<ObjectListResponse<RoleResponse>> GetUserRoles(RoleFilter filter);
    }
}
