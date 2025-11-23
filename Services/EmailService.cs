using System.Net;
using System.Net.Mail;

namespace EagleConnect.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var smtpServer = _configuration["Email:SmtpServer"] ?? "smtp.gmail.com";
                var smtpPort = int.Parse(_configuration["Email:SmtpPort"] ?? "587");
                var smtpUsername = _configuration["Email:SmtpUsername"];
                var smtpPassword = _configuration["Email:SmtpPassword"];
                var fromEmail = _configuration["Email:FromEmail"] ?? smtpUsername;
                var fromName = _configuration["Email:FromName"] ?? "EagleConnect";

                if (string.IsNullOrEmpty(smtpUsername) || string.IsNullOrEmpty(smtpPassword))
                {
                    _logger.LogWarning("Email configuration not set. Skipping email send to {Email}", to);
                    return; // Skip sending if not configured
                }

                using (var client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress(fromEmail ?? smtpUsername ?? "noreply@eagleconnect.com", fromName);
                        message.To.Add(new MailAddress(to));
                        message.Subject = subject;
                        message.Body = body;
                        message.IsBodyHtml = true;

                        await client.SendMailAsync(message);
                        _logger.LogInformation("Email sent successfully to {Email}", to);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email}", to);
                // Don't throw - allow registration/login to continue even if email fails
            }
        }

        public async Task SendEmailConfirmationAsync(string email, string callbackUrl)
        {
            var subject = "Confirm your email address";
            var body = $@"
                <html>
                <body>
                    <h2>Welcome to EagleConnect!</h2>
                    <p>Please confirm your email address by clicking the link below:</p>
                    <p><a href=""{callbackUrl}"">Confirm Email</a></p>
                    <p>If the link doesn't work, copy and paste this URL into your browser:</p>
                    <p>{callbackUrl}</p>
                    <p>This link will expire in 24 hours.</p>
                </body>
                </html>";
            
            await SendEmailAsync(email, subject, body);
        }

        public async Task SendPasswordResetAsync(string email, string callbackUrl)
        {
            var subject = "Reset your password";
            var body = $@"
                <html>
                <body>
                    <h2>Password Reset Request</h2>
                    <p>You requested to reset your password. Click the link below to reset it:</p>
                    <p><a href=""{callbackUrl}"">Reset Password</a></p>
                    <p>If the link doesn't work, copy and paste this URL into your browser:</p>
                    <p>{callbackUrl}</p>
                    <p>This link will expire in 1 hour.</p>
                    <p>If you didn't request this, please ignore this email.</p>
                </body>
                </html>";
            
            await SendEmailAsync(email, subject, body);
        }
    }
}

