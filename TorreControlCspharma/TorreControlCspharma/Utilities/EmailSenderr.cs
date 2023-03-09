using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace TorreControlCspharma.Utilities
{ 
        public class EmailSenderr : IEmailSender
        {
            private readonly ILogger _logger;

            public EmailSenderr(IOptions<AuthMessageSenderOptions> optionsAccessor,
                               ILogger<EmailSenderr> logger)
            {
                Options = optionsAccessor.Value;
                _logger = logger;
            }

            public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

            public async Task SendEmailAsync(string toEmail, string subject, string message)
            {
            Options.SendGridKey = "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";
                if (string.IsNullOrEmpty(Options.SendGridKey))
                {
                    throw new Exception("Null SendGridKey");
                }
                await Execute(Options.SendGridKey, subject, message, toEmail);
            }

            public async Task Execute(string apiKey, string subject, string message, string toEmail)
            {
                var client = new SendGridClient("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");
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("cspharmapro@gmail.com", "CsPharma"),
                    Subject = subject,
                    PlainTextContent = message,
                    HtmlContent = message
                };
                msg.AddTo(new EmailAddress(toEmail));


                msg.SetClickTracking(false, false);
                var response = await client.SendEmailAsync(msg);
                _logger.LogInformation(response.IsSuccessStatusCode
                                       ? $"Email to {toEmail} queued successfully!"
                                       : $"Failure Email to {toEmail}");
            }
        }
    }




