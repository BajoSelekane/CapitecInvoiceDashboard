using Microsoft.AspNetCore.Identity;


namespace CapitecDashboard.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public long? FormId { set; get; }
        public string? BaseLineId { set; get; }
        public string? TypeOfContactId { set; get; }



    }
}
