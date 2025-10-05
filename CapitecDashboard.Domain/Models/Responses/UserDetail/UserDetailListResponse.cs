
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Models.Responses.UserDetail
{
    public class UserDetailListResponse
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ProvinceId { get; set; }
        public string DistrictId { get; set; }
        public string SubDistrictId { get; set; }
        public string FacilityId { get; set; }
        public string OperationId { get; set; }
    }
}
