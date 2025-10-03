using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Interfaces.Services.QueryService;
using CapitecDashboard.Domain.Mapper;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Models.Responses.QueryResponse.AccessLevel;
using CapitecDashboard.Domain.Models.Responses.QueryResponse.Invoice;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Services.QueryServices
{

    public class InvoiceQueryService : BaseQueryService<InvoiceFilter, Invoice>, IInvoiceQueryService

    {
        public InvoiceQueryService(IQueryRepository<Invoice, InvoiceFilter> queryRepository,
                  ILogger<BaseService> logger) : base(queryRepository, logger)
        {

        }

        public override string ServiceName => nameof(InvoiceQueryService);

        public ObjectListResponse<InvoiceListResponse> Filter(InvoiceFilter filter)
        {
            var response = new ObjectListResponse<InvoiceListResponse>();
            var data = queryRepository.Filter(filter).ToList();

            var mappedData = data.Map();
            response.Data = mappedData;
            response.CodeStatus = ResponseStatus.Success;
            return response;
        }

        public ObjectResponse<InvoiceListResponse> Get(string id)
        {
            var response = new ObjectResponse<InvoiceListResponse>();
            var data = queryRepository.GetById(id);
            var mappedData = data.Map();
            response.Data = mappedData;
            response.CodeStatus = ResponseStatus.Success;
            return response;
        }
    }
}
