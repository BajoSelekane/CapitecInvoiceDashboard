using Microsoft.AspNetCore.Identity;


namespace CapitecDashboard.Domain.Entities
{
    public class Role : IdentityRole
    {
        public string ProgramDataId { get; set; }
      //  public ProgramData ProgramData { get; set; }
        public string? AccessLevelId { get; set; }
        public AccessLevel? AccessLevel { get; set; }

        public Role(string name, string programDataId, string accessLevelId)
        {
            base.Name = name;
            ProgramDataId = programDataId;
            AccessLevelId = accessLevelId;
        }

    }
}
