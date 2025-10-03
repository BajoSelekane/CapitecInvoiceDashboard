using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Services.CommandServices;
using Microsoft.Extensions.Logging;


namespace CapitecDashboard.Domain.Interfaces.Services.CommandService
{
    public class AccessLevelCommandService : BaseCommandService<AccessLevel>, IAccessLevelCommandService
    {
        private readonly IQueryRepository<AccessLevel, AccessLevelFilter> queryRepository;
        public AccessLevelCommandService(ICommandRepository<AccessLevel> commandRepository,
                              ILogger<BaseCommandService<AccessLevel>> logger,
                              IQueryRepository<AccessLevel, AccessLevelFilter> queryRepository) : base(commandRepository, logger)
        {
            this.queryRepository = queryRepository;
        }

        public override string ServiceName => nameof(AccessLevelCommandService);

        public BaseResponse Add(AccessLevelRequest request)
        {
            AccessLevel entity = AccessLevel.Create(request);

            return Create(entity);
        }

        public override void AfterCreation(AccessLevel entity)
        {

        }

        public BaseResponse Delete(BaseRequest request)
        {
            var accessLevel = queryRepository.GetById(request.Id);

            if (accessLevel == null)
            {
                return new BaseResponse
                {
                    CodeStatus = Enums.ResponseStatus.Fail,
                    Message = "Invalid Access level selected"
                };
            }
            accessLevel.UpdatedAt = DateTime.Now;
            accessLevel.UpdatedBy = request.UserId;
            var response = Delete(accessLevel);
            return response;
        }

        public BaseResponse Edit(AccessLevelRequest request)
        {
            var accessLevel = queryRepository.GetById(request.Id);
            if (accessLevel == null)
                return new BaseResponse
                {
                    CodeStatus = Enums.ResponseStatus.Fail,
                    Message = "Invalid Access level  selected"
                };
            accessLevel.UpdatedAt = DateTime.Now;
            accessLevel.UpdatedBy = request.UserId;
            accessLevel.Id = request.Id;
            accessLevel.Name = request.Name;
            var response = Update(accessLevel);
            return response;
        }
    }
}
