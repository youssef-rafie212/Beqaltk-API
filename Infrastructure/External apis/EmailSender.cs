using Core.Services_contracts;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Core.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            IConfigurationSection smtpSettings = _configuration.GetSection("SmtpSettings");
            SmtpClient smtpClient = new()
            {
                Host = smtpSettings["Host"]!,
                Port = int.Parse(smtpSettings["Port"]!),
                EnableSsl = Convert.ToBoolean(smtpSettings["EnableSsl"]!),
                Credentials = new NetworkCredential() { UserName = smtpSettings["Username"], Password = smtpSettings["Password"] }
            };

            MailMessage mailMessage = new()
            {
                From = new MailAddress(smtpSettings["Username"]!, "Beqaltk App"),
                Subject = subject,
                Body = message
            };

            mailMessage.To.Add(toEmail);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch
            {
                throw new Exception("Email failed to send");
            }
        }
    }
}
