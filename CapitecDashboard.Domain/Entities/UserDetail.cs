using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Entities
{
    public class UserDetail : BaseEntity
    {
        public string CustomerId { get; set; } = string.Empty;
        public Customer? Customer { get; set; }
        public Guid InvoiceId { get; set; } 
        public Invoice? Invoice { get; set; }
        public string PaymentId { get; set; } = string.Empty;
         public Payment? Payment { get; set; }
        public decimal AmountPaid {  get; set; }
        public InvoiceItem? InvoiceItem { get; set; }
        public string UserId { get; set; }

        public static UserDetail Create(UserDetailRequest request)
        {
            return new UserDetail
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = request.UserId,
                UpdatedBy = request.UserId,
                UserId = request.UserId,
                InvoiceId = request.InvoiceId,
                CustomerId = request.CustomerId,
                AmountPaid = request.AmountPaid
            };
        }

       
    }
}
