using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Interfaces.Services.CommandService;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Services.CommandServices
{
    public class UserDetailCommandService : BaseCommandService<UserDetail>, IUserDetailCommandService
    {
        private readonly IQueryRepository<UserDetail, UserDetailFilter> queryRepository;
        public UserDetailCommandService(ICommandRepository<UserDetail> commandRepository,
            ILogger<BaseCommandService<UserDetail>> logger, IQueryRepository<UserDetail, UserDetailFilter> queryRepository) : base(commandRepository, logger)
        {
            this.queryRepository = queryRepository;
        }

        public override string ServiceName => nameof(UserDetailCommandService);

        public BaseResponse Add(UserDetailRequest request)
        {
            UserDetail entiry = UserDetail
                .Create(request);

            return Create(entiry);
        }

        public override void AfterCreation(UserDetail entity)
        {

        }

        public BaseResponse Delete(BaseRequest request)
        {
            var user = queryRepository.GetById(request.Id);

            if (user == null)
                return new BaseResponse
                {
                    CodeStatus = Enums.ResponseStatus.Fail,
                    Message = "Invalid data selected"
                };

            user.Status = Enums.EntityStatus.Deleted;
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = request.UserId;
            var response = Delete(user);

            return response;
        }

        public BaseResponse Edit(UserDetailRequest request)
        {
            var user = queryRepository.GetById(request.Id);

            if (user == null)
                return new BaseResponse
                {
                    CodeStatus = Enums.ResponseStatus.Fail,
                    Message = "Invalid data selected"
                };

            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = request.UserId;
            var response = Update(user);

            return response;
        }
    }
}
