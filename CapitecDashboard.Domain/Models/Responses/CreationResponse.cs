

namespace CapitecDashboard.Domain.Models.Responses
{
    public class CreationResponse<T> : BaseResponse where T : class
    {
        public T? CreatedEntity { get; set; }
    }
}
