using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public string? CustomerId { get; set; }


        public static Invoice Create(InvoiceRequest request)
        {
            return new Invoice
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = request.UserId,
                UpdatedBy = request.UserId,
                CustomerId = request.CustomerId
            };
        }


        // public Guid Id { get; set; }
       // public string CustomerId { get; set; } = "";
       // public Customer? Customer { get; set; }

       // public DateTime IssueDate { get; set; } = DateTime.UtcNow;
       // public DateTime DueDate { get; set; }
       //// public InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;


       // [Column(TypeName = "decimal(18,2)")]
       // public decimal SubTotal { get; set; }
       // [Column(TypeName = "decimal(18,2)")]
       // public decimal TaxAmount { get; set; }
       // [Column(TypeName = "decimal(18,2)")]
       // [Precision(16, 2)]
       // public decimal Total { get; set; }
       // [Column(TypeName = "decimal(18,2)")]
       // public decimal AmountPaid { get; set; }





       // public ICollection<InvoiceItem> Items { get; private set; } = new List<InvoiceItem>();
       // public List<Payment> Payments { get; set; } = new();
       // public Guid InvoiceId { get; internal set; }
    }

}
