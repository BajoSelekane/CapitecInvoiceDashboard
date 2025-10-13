using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Services.CommandServices;
using Microsoft.Extensions.Logging;


namespace CapitecDashboard.Domain.Interfaces.Services.CommandService
{
    public interface IAccessLevelCommandService : IBaseCommandService<AccessLevel>
    {
        BaseResponse Add(AccessLevelRequest request);
        BaseResponse Edit(AccessLevelRequest request);
        BaseResponse Delete(BaseRequest request);
    }
}
