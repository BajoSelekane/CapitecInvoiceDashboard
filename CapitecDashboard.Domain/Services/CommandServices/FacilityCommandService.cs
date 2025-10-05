using Microsoft.Extensions.Logging;
using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Interfaces.Services.CommandService;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Services.CommandServices
{
    public class FacilityCommandService : BaseCommandService<Facility>, IFacilityCommandService
    {
        private readonly IQueryRepository<Facility, FacilityFilter> queryRepository;
        public FacilityCommandService(ICommandRepository<Facility> commandRepository,
            ILogger<BaseCommandService<Facility>> logger,
            IQueryRepository<Facility, FacilityFilter> queryRepository) : base(commandRepository, logger)
        {
            this.queryRepository = queryRepository;
        }

        public override string ServiceName => nameof(FacilityCommandService);

        public BaseResponse Add(FacilityRequest request)
        {
            Facility entity = Facility.Create(request);

            return Create(entity);
        }

        public override void AfterCreation(Facility entity)
        {

        }

        public BaseResponse Delete(BaseRequest request)
        {
            var facility = queryRepository.GetById(request.Id);

            if (facility == null)
            {
                return new BaseResponse
                {
                    CodeStatus = Enums.ResponseStatus.Fail,
                    Message = "Invalid facility selected"
                };
            }

            facility.UpdatedAt = DateTime.Now;
            facility.UpdatedBy = request.UserId;
            facility.Status = Enums.EntityStatus.Deleted;
            var response = Delete(facility);

            return response;
        }

        public BaseResponse Edit(FacilityRequest request)
        {
            var facility = queryRepository.GetById(request.Id);

            if (facility == null)
                return new BaseResponse
                {
                    CodeStatus = Enums.ResponseStatus.Fail,
                    Message = "Invalid facility selected"
                };

            facility.UpdatedAt = DateTime.Now;
            facility.UpdatedBy = request.UserId;
            facility.SubDistrictId = request.SubDistrictId;
            facility.Name = request.Name;
            var response = Update(facility);

            return response;
        }
    }
}
