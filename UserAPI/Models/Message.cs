using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace UserAPI.Models
{
    public class Message
    {
        public List<MailboxAddress> Remittee { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> remittee, string subject, 
            int userId, string code)
        {
            Remittee = new List<MailboxAddress>();
            Remittee.AddRange(remittee.Select(r => new MailboxAddress(r)));
            Subject = subject;
            Content = $"https://localhost:6001/registration/confirmation/?accountId={userId}&activationCode={code}";
        }

    }
}
