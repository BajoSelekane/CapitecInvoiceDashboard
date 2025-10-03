using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Models.Responses.UserDetail
{
    public class UserDetailResponse
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string InvoiceId { get; set; }
        public string PaymentId { get; set; }  
        public string UserId { get; set; }
    }
}
