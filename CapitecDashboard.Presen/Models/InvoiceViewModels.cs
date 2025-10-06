namespace CapitecDashboard.Presen.Models
{
    public class InvoiceListItem
    {
        public string Id { get; set; } = string.Empty;
        public string? CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class InvoiceEditModel
    {
        public string? Id { get; set; }
        public string? CustomerId { get; set; }
    }
}


