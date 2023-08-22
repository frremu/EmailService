

//This implementation is not working

using Hangfire;
using System;
using System.Net;
using System.Net.Mail;

namespace EmailMicroService.Services
{
    public class EmailService
    {
        public void SendEmail(string recipient, string subject, string body)
        {
            // Set up email settings
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 465,
                Credentials = new NetworkCredential("umerfarooqnu@gmail.com", "Whiterose420"),
                EnableSsl = true,
            };



            var mailMessage = new MailMessage
            {
                From = new MailAddress("umerfarooqnu@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(recipient);



            try
            {
                // Send the email
                smtpClient.Send(mailMessage);
                Console.WriteLine($"Email sent to {recipient}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex}");
                // Print more details if available
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException}");
                }
            }
        }



        public void EnqueueEmail(string recipient, string subject, string body)
        {
            //BackgroundJob.Enqueue(() => SendEmail(recipient, subject, body));\
            SendEmail(recipient, subject, body);
        }
    }


}

