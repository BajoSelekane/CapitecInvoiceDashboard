using CapitecDashboard.Domain.Enums;


namespace CapitecDashboard.Domain.Models.Responses
{
    public class BaseResponse
    {
        public ResponseStatus CodeStatus { get; set; }
        public string Status { get { return CodeStatus.ToString().ToLower(); } }
        public string Message { get; set; } = string.Empty;
    }
}
