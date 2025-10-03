using CapitecDashboard.Domain.Enums;


namespace CapitecDashboard.Domain.Models.Responses
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public ImplementationType UserTypeId { get; set; }
        public string UserType { get; set; }
    }
}
