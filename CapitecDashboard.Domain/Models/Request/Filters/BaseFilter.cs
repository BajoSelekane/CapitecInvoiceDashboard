using CapitecDashboard.Domain.Enums;


namespace CapitecDashboard.Domain.Models.Request.Filters
{
    public class BaseFilter
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public int? Page { get; set; }
        public ImplementationType? ImplementationType { get; set; }
    }
}
