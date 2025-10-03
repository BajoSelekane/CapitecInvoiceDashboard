using CapitecDashboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Models.Responses.QueryResponse.Dashboard
{
	public class IncompleteFormListResponse
	{
        public long FormId { get; set; }
        //public FormStatus? FormStatus { get; set; }
         public string CreatedAt { get; set; }
         public string UuId { get; set; }
         public string FullName { get; set; }
         public long ClientId { get; set; }
    }
}
