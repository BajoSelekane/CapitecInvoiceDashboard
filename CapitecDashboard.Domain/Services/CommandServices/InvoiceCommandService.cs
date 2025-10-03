using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Responses;


namespace CapitecDashboard.Domain.Services.CommandServices
{
    public interface IInvoiceCommandService : IBaseCommandService<Invoice>
    {
        BaseResponse Add(InvoiceRequest request);
        BaseResponse Update(InvoiceRequest request);
        BaseResponse Delete(BaseRequest request);
    }
}
