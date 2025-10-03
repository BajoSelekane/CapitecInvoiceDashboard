using CapitecDashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Models.Request
{
   public class UserDetailRequest : BaseRequest
    {
        //public string? Id { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public Customer? Customer { get; set; }
        public Guid InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public string PaymentId { get; set; } = string.Empty;
        public Payment? Payment { get; set; }
        public decimal AmountPaid { get; set; }
        public InvoiceItem? InvoiceItem { get; set; }
        public string UserId { get; set; }

    }
}
