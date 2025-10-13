

namespace CapitecDashboard.Domain.Models.Responses
{
    public class ObjectListResponse<T> : BaseResponse where T : class
    {
        public ObjectListResponse()
        {
            Data = new List<T>();
        }

        public List<T> Data { get; set; }
    }

}
