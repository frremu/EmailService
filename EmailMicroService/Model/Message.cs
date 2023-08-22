using MimeKit;

namespace EmailMicroService.Model
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }

        public string Content { get; set; }

        public Message(IEnumerable<string> to, string sub, string con) {


            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x=> new MailboxAddress("email",x)));
            Subject = sub;
            Content = con;
        }

    }
}
