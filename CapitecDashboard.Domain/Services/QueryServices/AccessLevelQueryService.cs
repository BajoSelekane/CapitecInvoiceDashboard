using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Interfaces.Services.QueryService;
using CapitecDashboard.Domain.Mapper;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Models.Responses.QueryResponse.AccessLevel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Services.QueryServices
{
    public class AccessLevelQueryService : BaseQueryService<AccessLevelFilter, AccessLevel>, IAccessLevelQueryService

    {
        public AccessLevelQueryService(IQueryRepository<AccessLevel, AccessLevelFilter> queryRepository,
                  ILogger<BaseService> logger) : base(queryRepository, logger)
        {

        }

        public override string ServiceName => nameof(AccessLevelQueryService);

        public ObjectListResponse<AccessLevelListResponse> Filter(AccessLevelFilter filter)
        {
            var response = new ObjectListResponse<AccessLevelListResponse>();
            var data = queryRepository.Filter(filter).ToList();

            var mappedData = data.Map();
            response.Data = mappedData;
            response.CodeStatus = ResponseStatus.Success;
            return response;
        }

        public ObjectResponse<AccessLevelListResponse> Get(string id)
        {
            var response = new ObjectResponse<AccessLevelListResponse>();
            var data = queryRepository.GetById(id);
            var mappedData = data.Map();
            response.Data = mappedData;
            response.CodeStatus = ResponseStatus.Success;
            return response;
        }
    }
}
