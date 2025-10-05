using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Interfaces.Services.CommandService
{
    public interface IUserFacilityCommandService : IBaseCommandService<UserFacility>
    {
        BaseResponse Add(UserFacilityRequest request);
        BaseResponse Edit(UserFacilityRequest request);
        BaseResponse Delete(BaseRequest request);
    }
}
