using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Models.Request
{
    public class FacilityRequest : BaseRequest
    {
        public string Name { get; set; }
        public string SubDistrictId { get;  set; }
    }
}
