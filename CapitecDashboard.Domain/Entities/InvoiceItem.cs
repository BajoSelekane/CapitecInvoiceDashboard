using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Entities
{
    public class InvoiceItem : BaseEntity
    {

        public Guid InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LineTotal { get; set; }
    }

}
