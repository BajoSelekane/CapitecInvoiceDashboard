using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Interfaces.Services.QueryService;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Models.Responses.UserDetail;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Services.QueryServices
{
    public class UserDetailQueryService : BaseQueryService<UserDetailFilter, UserDetail>, IUserDetailQueryService
    {
        public UserDetailQueryService(IQueryRepository<UserDetail, UserDetailFilter> queryRepository, ILogger<BaseService> logger) : base(queryRepository, logger)
        {
        }

        public override string ServiceName => nameof(UserDetailQueryService);

        public ObjectResponse<UserDetailResponse> Get(string id)
        {
            var response = new ObjectResponse<UserDetailResponse>();

            var data = queryRepository.GetById(id);

            var transformedData = new UserDetailResponse
            {
                Id = data.Id,
                ProvinceId = data.ProvinceId,
                DistrictId = data.DistrictId,
                SubDistrictId = data.SubDistrictId,
                FacilityId = data.FacilityId,
                UserId = data.UserId,
            };


            response.Data = transformedData;
            response.CodeStatus = ResponseStatus.Success;

            return response;

        }

        public ObjectListResponse<UserDetailListResponse> Filter(UserDetailFilter filter)
        {
            var response = new ObjectListResponse<UserDetailListResponse>();
            var data = queryRepository.Filter(filter).ToList();

            var mappedData = new List<UserDetailListResponse>();

            foreach (var item in data)
            {
                mappedData.Add(new UserDetailListResponse
                {
                    Id = item.Id,
                    ProvinceId = item.ProvinceId,
                    DistrictId = item.DistrictId,
                    SubDistrictId = item.SubDistrictId,
                    FacilityId = item.FacilityId,
                    UserId = item.UserId,
                });
            }
            response.Data = mappedData;
            response.CodeStatus = ResponseStatus.Success;

            return response;
        }

        public ObjectResponse<UserDetailResponse> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
