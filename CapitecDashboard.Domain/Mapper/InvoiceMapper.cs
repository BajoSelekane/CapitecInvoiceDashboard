using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Responses.QueryResponse.AccessLevel;
using CapitecDashboard.Domain.Models.Responses.QueryResponse.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Mapper
{
   
    public static class InvoiceMapper
    {

        public static InvoiceListResponse Map(this Invoice item)
        {
            return new InvoiceListResponse
            {
                CustomerId = item.CustomerId,
                IssueDate = item.IssueDate,
                DueDate = item.DueDate,
                //Status = item.Status,
                SubTotal = item.SubTotal,
                TaxAmount = item.TaxAmount,
                Total = item.Total,
                AmountPaid = item.AmountPaid,
                
            };
        }

        public static List<InvoiceListResponse> Map(this List<Invoice> entities)
        {
            var mapped = new List<InvoiceListResponse>();
            foreach (var item in entities)
            {
                mapped.Add(Map(item));
            }
            return mapped;
        }
    }
}
