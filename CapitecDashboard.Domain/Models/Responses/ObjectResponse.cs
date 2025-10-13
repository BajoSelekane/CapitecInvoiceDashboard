

namespace CapitecDashboard.Domain.Models.Responses
{
    public class ObjectResponse<T> : BaseResponse where T : class
    {
        public T? Data { get; set; }
    }
}
