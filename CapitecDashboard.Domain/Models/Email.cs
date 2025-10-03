using MimeKit;


namespace CapitecDashboard.Domain.Models
{
    public class Email
    {
      

        public List<MailboxAddress> To { get; set; }
        public List<MailboxAddress> CC { get; set; }

        public string Subject { get; set; }
        public string Message { get; set; }

        public static Email Create(Dictionary<string, string>? to, Dictionary<string, string>? cc, string subject, string message)
        {
            var tos = new List<MailboxAddress>();
            tos.AddRange(to.Select(x => new MailboxAddress(x.Value, x.Key)));

            List<MailboxAddress> ccs = null;

            if (cc != null && cc.Values.Count() > 0)
            {
                ccs = new List<MailboxAddress>();
                ccs.AddRange(cc.Select(x => new MailboxAddress(x.Value, x.Key)));
            }

            return new Email
            {
                To = tos,
                CC = ccs,
                Subject = subject,
                Message = message
            };
        }
    }
}


//public List<MailboxAddress> To { get; set; }
//public string Subject { get; set; }
//public string Message { get; set; }

//public static Email Create(Dictionary<string, string> to, string subject, string message)
//{
//    var tos = new List<MailboxAddress>();
//    tos.AddRange(to.Select(x => new MailboxAddress(x.Value, x.Key)));

//    return new Email
//    {
//        To = tos,
//        Subject = subject,
//        Message = message
//    };
//}