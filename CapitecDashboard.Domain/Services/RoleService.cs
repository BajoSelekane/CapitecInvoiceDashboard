using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Interfaces;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;
        public RoleService(RoleManager<Role> roleManager,
            UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public ObjectListResponse<RoleResponse> Filter(RoleFilter filter)
        {
            var response = new ObjectListResponse<RoleResponse>();

            var rolseResponse = new List<RoleResponse>();
            var roles = roleManager.Roles.ToList();

            foreach (var role in roles)
            {
                rolseResponse.Add(new RoleResponse
                {
                    Id = role.Id,
                    Name = role.Name,
                    ProgramDataId = role.ProgramDataId,

                });
            }

            response.Data = rolseResponse;
            response.CodeStatus = ResponseStatus.Success;
            return response;
        }

        public ObjectListResponse<RoleResponse> GetRoleByProgramDataId(RoleFilter filter)
        {
            var response = new ObjectListResponse<RoleResponse>();

            var rolseResponse = new List<RoleResponse>();

            var roles = roleManager.Roles.Where(x => x.ProgramDataId == filter.ProgramDataId).ToList();

            foreach (var role in roles)
            {
                rolseResponse.Add(new RoleResponse
                {
                    Id = role.Id,
                    Name = role.Name,
                    ProgramDataId = role.ProgramDataId,

                });
            }

            response.Data = rolseResponse;
            response.CodeStatus = ResponseStatus.Success;
            return response;
        }

        public async Task<ObjectListResponse<RoleResponse>> GetUserRoles(RoleFilter filter)
        {
            var response = new ObjectListResponse<RoleResponse>();

            var rolseResponse = new List<RoleResponse>();
            var user = await userManager.FindByIdAsync(filter.UserId);
            var userRoles = await userManager.GetRolesAsync(user);

            var roles = await roleManager.Roles.ToListAsync();

            //var roles = roleManager.Roles.ToList();

            foreach (var role in userRoles)
            {
                var foundRole = roles
                    .FirstOrDefault(x => x.Name.Equals(role, StringComparison.InvariantCultureIgnoreCase));

                if (foundRole != null)
                {
                    rolseResponse.Add(new RoleResponse
                    {
                        Id = foundRole.Id,
                        Name = foundRole.Name,
                        ProgramDataId = foundRole.ProgramDataId,

                    });
                }

            }

            response.Data = rolseResponse;
            response.CodeStatus = ResponseStatus.Success;
            return response;
        }
    }
}
