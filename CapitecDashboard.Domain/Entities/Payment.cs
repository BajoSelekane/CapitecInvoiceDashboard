using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace CapitecDashboard.Domain.Entities
{
    public class Payment:BaseEntity
    {

       // public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public required Invoice Invoice { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string? Method { get; set; }
        public string? Reference { get; set; }
    }

}
