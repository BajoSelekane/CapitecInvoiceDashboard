using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Responses;


namespace CapitecDashboard.Domain.Services.CommandServices
{
    public interface IAccessLevelCommandService : IBaseCommandService<AccessLevel>
    {
        BaseResponse Add(AccessLevelRequest request);
        BaseResponse Edit(AccessLevelRequest request);
        BaseResponse Delete(BaseRequest request);
    }
}
