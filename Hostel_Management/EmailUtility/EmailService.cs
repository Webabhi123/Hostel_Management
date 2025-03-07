using MimeKit;
using MailKit.Net.Smtp;

namespace Hostel_Management.EmailUtility
{
    public interface IEmailService
    {
        Task SendEmailAsync(string ToEmail, string subject, string body);
    }
    public class EmailService:IEmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Abhishek Dass", "abhishekdass1913051001@gmail.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            message.Body = new TextPart("Plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("abhishekdass1913051001@gmail.com", "tqax ibyp xevu whhn");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                    //Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"falied to send message:{ex.Message}");
                }
            }
        }
    }
}
