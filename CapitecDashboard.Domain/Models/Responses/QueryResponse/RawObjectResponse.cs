using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Models.Responses.QueryResponse
{
    public class RawObjectResponse<T> : BaseResponse where T : class
    {
        public T? Data { get; set; }
    }
}
