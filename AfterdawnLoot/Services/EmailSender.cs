using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace WebPWrecover.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("jeremyp@outlook.com");

            var to = new EmailAddress(email);
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            return client.SendEmailAsync(msg);
        }

    }
}