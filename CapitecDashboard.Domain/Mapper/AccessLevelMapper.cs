using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Responses.QueryResponse.AccessLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Mapper
{
    public static class AccessLevelMapper
    {

        public static AccessLevelListResponse Map(this AccessLevel item)
        {
            return new AccessLevelListResponse
            {
                Id = item.Id,
                Name = item.Name,
            };
        }

        public static List<AccessLevelListResponse> Map(this List<AccessLevel> entities)
        {
            var mapped = new List<AccessLevelListResponse>();
            foreach (var item in entities)
            {
                mapped.Add(Map(item));
            }
            return mapped;
        }
    }
}
