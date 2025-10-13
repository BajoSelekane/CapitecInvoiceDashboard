using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Entities
{
    public class SubDistrict : BaseEntity
    {
        public string Name { get; set; }
        public string? DistrictId { get; set; }
        public District District { get; set; }

        public static SubDistrict Create(string name, string? districtId, string userId)
        {
            return new SubDistrict
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = userId,
                UpdatedBy = userId,
                DistrictId = districtId,
                Name = name,
            };
        }
    }
}
