using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using asp_dot_net_core_first_app.Models;
using System.Net;

namespace asp_dot_net_core_first_app.Code
{
    public class EmailService : IEmailService
    {
        //private readonly IConfiguration _configuration;
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                email.To.Add(MailboxAddress.Parse(_smtpSettings.AdminEmail));
                email.Bcc.Add(MailboxAddress.Parse(_smtpSettings.BccEmail));
                email.Subject = $"New query: {subject}";

                var builder = new BodyBuilder
                {
                    HtmlBody = body // You can set plain text as well: PlainTextBody = "Text"
                };
                email.Body = builder.ToMessageBody();

                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using var smtp = new SmtpClient();

                // Connect to the SMTP server
                await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, _smtpSettings.UseSsl);

                // Authenticate if username/password is provided
                if (!string.IsNullOrEmpty(_smtpSettings.Username) && !string.IsNullOrEmpty(_smtpSettings.Password))
                {
                    await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                }

                // Send the email
                string response = await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                // Email sent successfully
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (replace with your logging mechanism)
                Console.WriteLine($"Email sending failed: {ex.Message}");

                // Email failed
                return false;
            }
            //finally
            //{
            //    await smtp.DisconnectAsync(true);
            //}
        }
    }
}