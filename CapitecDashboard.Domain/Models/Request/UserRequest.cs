using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Models.Request
{
    public class UserRequest : BaseRequest
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        public string Phone { get; set; }
        public string? CustomerId { get; set; }
        public List<string> Customer { get; set; }
        public Guid? InvoiceId { get; set; }
        public List<string> Invoice { get; set; }
        public Guid? PaymentId { get; set; }
        public List<string> Payment { get; set; }
        public List<string>InvoiceItem { get; set; }
        public List<string> Roles { get; set; }
        public string RoleId { get; set; }
        public string? Password { get; set; }

        public ICollection<Invoice?> Invoices { get; set; }
        public ICollection<InvoiceItem?> InvoiceItems { get; set; }
        public InvoiceStatus? Status { get; set; }
        public ImplementationType ImplementationType { get; set; }
    }
}
