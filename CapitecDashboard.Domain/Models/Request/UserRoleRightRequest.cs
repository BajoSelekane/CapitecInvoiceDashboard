

namespace CapitecDashboard.Domain.Models.Request
{
    public class UserRoleRightRequest : BaseRequest
    {
        public string? RoleId { get; set; }
        public string? RightId { get; set; }
    }
}
