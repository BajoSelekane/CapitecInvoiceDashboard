using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Responses;
using CapitecDashboard.Domain.Services.CommandServices;

namespace CapitecDashboard.Domain.Interfaces.Services.CommandService
{
    public interface IInvoiceCommandService : IBaseCommandService<Invoice>
    {
        BaseResponse Add(InvoiceRequest request);
        BaseResponse Update(InvoiceRequest request);
        BaseResponse Delete(BaseRequest request);
    }
}
