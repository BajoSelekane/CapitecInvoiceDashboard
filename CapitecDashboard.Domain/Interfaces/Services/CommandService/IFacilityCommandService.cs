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
    public interface IFacilityCommandService : IBaseCommandService<Facility>
    {
        BaseResponse Add(FacilityRequest request);
        BaseResponse Edit(FacilityRequest request);
        BaseResponse Delete(BaseRequest request);
    }
}
