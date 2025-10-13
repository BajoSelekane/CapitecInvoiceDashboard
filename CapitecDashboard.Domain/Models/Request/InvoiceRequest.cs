using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Models.Request
{
    public class InvoiceRequest:BaseRequest
    {
        // public Guid Id { get; set; }
        public string? CustomerId { get; set; } = "";
        
    }
}
