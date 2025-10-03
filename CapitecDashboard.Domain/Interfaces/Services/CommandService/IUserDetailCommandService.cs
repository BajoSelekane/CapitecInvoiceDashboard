using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Services.CommandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Interfaces.Services.CommandService
{
    public interface IUserDetailCommandService : IBaseCommandService<UserDetail>
    {
        BaseResponse Add(UserDetailRequest request);
        BaseResponse Edit(UserDetailRequest request);
        BaseResponse Delete(BaseRequest request);
    }
}
