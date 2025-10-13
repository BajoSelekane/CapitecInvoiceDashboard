using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Utils;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CapitecDashboard.API.Utils
{
    public class WebSecurity : IWebSecurity
    {
        IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        public WebSecurity(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public string UserId => httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public string Role => GetRole().Result;

        private async Task<string> GetRole()
        {
            var roles = await userManager.GetRolesAsync(User);

            var role = roles.FirstOrDefault();

            return string.IsNullOrEmpty(role) ? "Data Capturer" : role;
        }
        public User User { get { return (userManager.Users.FirstOrDefault(x => x.Id == UserId)); } }

        public bool HasRole(string role)
        {
            //var userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = userManager.Users.FirstOrDefault(x => x.Id == User.Id);
            var iss = userManager.IsInRoleAsync(user, role).Result;
            return iss;
        }

        public bool InRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
