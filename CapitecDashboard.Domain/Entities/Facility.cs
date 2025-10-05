using CapitecDashboard.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Entities
{
    public class Facility : BaseEntity
    {
        public string Name { get; set; }
        public string SubDistrictId { get; set; }
        public SubDistrict SubDistrict { get; set; }

  

        internal static Facility Create(FacilityRequest request)
        {
            return new Facility
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = request.UserId,
                UpdatedBy = request.UserId,
                SubDistrictId = request.SubDistrictId,
                Name = request.Name,
            };
        }
    }
}
