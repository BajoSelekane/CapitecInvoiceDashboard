using CapitecDashboard.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Entities
{
    public class UserFacility : BaseEntity
    {
        public string FacilityId { get; set; }
        public Facility? Facility { get; set; }
        public string UserId { get; set; }

        public static UserFacility Create(UserFacilityRequest request)
        {
            return new UserFacility
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = request.UserId,
                UpdatedBy = request.UserId,
                UserId = request.FacilityUserId,
                FacilityId = request.FacilityId,
            };
        }
    }
}
