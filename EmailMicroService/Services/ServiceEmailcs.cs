using EmailMicroService.Model;
using Hangfire;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailMicroService.Services
{
    public class ServiceEmailcs : IEmailService
    {
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);

        }

        private void Send(MimeMessage emailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect("Enter your domain smtp", 465, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("email", "password");

                client.Send(emailMessage);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", "email"));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Content
            };
            return emailMessage;
        }

        public void EnqueueEmail(Message message)
        {
            //BackgroundJob.Enqueue(() => SendEmail(message));
            SendEmail(message);
            //BackgroundJob.Enqueue<ServiceEmailcs>(x => x.SendEmail(message));
        }

    }
}
