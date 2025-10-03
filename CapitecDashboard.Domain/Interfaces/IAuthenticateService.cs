using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Interfaces
{
    public interface IAuthenticateService
    {
        Task<ObjectResponse<UserResponse>> Register(UserRequest request);
        Task<ObjectResponse<UserResponse>> Update(UserRequest request);
        ObjectListResponse<UserResponse> Filter(UserFilter filter);
        ObjectResponse<UserResponse> GetUserById(string userId);
        Task<BaseResponse> CreateNewRole(RoleRequest request);

        Task<BaseResponse> RemoveUserRole(RoleDeleteRequest request);
        Task<BaseResponse> AddUserToRole(RoleAddRequest request);
        Task<ObjectResponse<UserResponse>> Login(LoginRequest request);
        BaseResponse AssignUserToFacility(UserFacilityRequest request);
        BaseResponse SaveUserDetail(UserDetailRequest request);

    }
}
