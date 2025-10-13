using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Interfaces.Services.CommandService;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;


namespace CapitecDashboard.Domain.Services.CommandServices
{
    public class InvoiceCommandService : BaseCommandService<Invoice>, IInvoiceCommandService
    {
        private readonly IQueryRepository<Invoice, InvoiceFilter> queryRepository;
        public InvoiceCommandService(ICommandRepository<Invoice> commandRepository,
                              ILogger<BaseCommandService<Invoice>> logger,
                              IQueryRepository<Invoice, InvoiceFilter> queryRepository) : base(commandRepository, logger)
        {
            this.queryRepository = queryRepository;
        }

        public override string ServiceName =>nameof(InvoiceCommandService);

        public BaseResponse Add(InvoiceRequest request)
        {
            Invoice ent = Invoice.Create(request);
            return Create(ent);
        }

        public override void AfterCreation(Invoice entity)
        {
           
        }

        public BaseResponse Delete(BaseRequest request)
        {
            var invoice = queryRepository.GetById(request.Id);

            if (invoice == null)
            {
                return new BaseResponse
                {
                    CodeStatus = Enums.ResponseStatus.Fail,
                    Message = "Invalid Invalid invoice_ID selected"
                };
            }
            invoice.UpdatedAt = DateTime.Now;
            invoice.UpdatedBy = request.UserId;
            var response = Delete(invoice);
            return response;
        }

        public BaseResponse Update(InvoiceRequest request)
        {
            var invoice = queryRepository.GetById(request.Id);
            if (invoice == null)
                return new BaseResponse
                {
                    CodeStatus = Enums.ResponseStatus.Fail,
                    Message = "Invalid invoice_ID"
                };
            invoice.UpdatedAt = DateTime.Now;
            invoice.UpdatedBy = request.UserId;
            invoice.Id = request.Id;
            invoice.CustomerId = request.CustomerId;
            var response = Update(invoice);
            return response;
        }
    }
}
//public string CustomerId { get; set; } = "";
//public Customer? Customer { get; set; }

//public DateTime IssueDate { get; set; } = DateTime.UtcNow;
//public DateTime DueDate { get; set; }
//public InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;


//[Column(TypeName = "decimal(18,2)")]
//public decimal SubTotal { get; set; }
//[Column(TypeName = "decimal(18,2)")]
//public decimal TaxAmount { get; set; }
//[Column(TypeName = "decimal(18,2)")]
//[Precision(16, 2)]
//public decimal Total { get; set; }
//[Column(TypeName = "decimal(18,2)")]
//public decimal AmountPaid { get; set; }