using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Entities
{
    public class AccessLevel : BaseEntity
    {
        public string Name { get; set; }

        public static AccessLevel Create(AccessLevelRequest request)
        {
            return new AccessLevel
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = request.UserId,
                UpdatedBy = request.UserId,
                Name = request.Name,
            };
        }
    }
}
