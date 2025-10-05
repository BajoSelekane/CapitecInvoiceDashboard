using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Entities
{
    public class Province : BaseEntity
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }

        internal static Province Create(string name, string countryId, string userId, string abbreviation)
        {
            return new Province
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = userId,
                UpdatedBy = userId,
                CountryId = countryId,
                Name = name,
                Abbreviation = abbreviation,
            };
        }
    }
}
