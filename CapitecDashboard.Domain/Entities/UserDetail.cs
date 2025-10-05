using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Entities
{
    public class UserDetail : BaseEntity
    {
        public string ProvinceId { get; set; } = string.Empty;
        public Province? Province { get; set; }
        public string DistrictId { get; set; } = string.Empty;
        public District? District { get; set; }
        public string SubDistrictId { get; set; } = string.Empty;
        public SubDistrict? SubDistrict { get; set; }
        public string FacilityId { get; set; } = string.Empty;
        public Facility? Facility { get; set; }
        public string UserId { get; set; }

        public static UserDetail Create(UserDetailRequest request)
        {
            return new UserDetail
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = request.UserId,
                UpdatedBy = request.UserId,
                UserId = request.UserDetailId,
                ProvinceId = request.ProvinceId,
                DistrictId = request.DistrictId,
                SubDistrictId = request.SubDistrictId,
                FacilityId = request.FacilityId,
            };
        }
    }
}
