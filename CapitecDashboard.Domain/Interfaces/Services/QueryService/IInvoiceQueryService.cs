using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Models.Responses.QueryResponse.AccessLevel;
using CapitecDashboard.Domain.Models.Responses.QueryResponse.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Interfaces.Services.QueryService
{
    public interface IInvoiceQueryService : IBaseQueryService<InvoiceFilter, Invoice>
    {
        ObjectListResponse<InvoiceListResponse> Filter(InvoiceFilter filter);
        ObjectResponse<InvoiceListResponse> Get(string id);
    }
}
