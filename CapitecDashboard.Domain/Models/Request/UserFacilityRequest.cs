using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Models.Request
{
    public class UserFacilityRequest : BaseRequest
    {
        public string FacilityId { get; set; }
        public string FacilityUserId { get; set; }
    }
}
