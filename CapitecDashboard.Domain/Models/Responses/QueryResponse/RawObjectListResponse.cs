

namespace CapitecDashboard.Domain.Models.Responses.QueryResponse
{
    public class RawObjectListResponse<T> : BaseResponse where T : class
    {
        public IQueryable<T>? Data { get; set; }
    }
}
