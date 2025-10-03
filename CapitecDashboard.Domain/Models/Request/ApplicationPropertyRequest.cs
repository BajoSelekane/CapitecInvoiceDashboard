

namespace CapitecDashboard.Domain.Models.Request
{
    public class ApplicationPropertyRequest : BaseRequest
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? DataType { get; set; }
    }
}
