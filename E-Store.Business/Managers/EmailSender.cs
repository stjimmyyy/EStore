namespace E_Store.Business.Managers
{
    using MimeKit;
    using MailKit.Net.Smtp;
    using MimeKit.Text;
    
    using Classes;
    using Interfaces;
    
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration configuration;
        private const string emailSender = "dafgasg94@gmail.com";

        public EmailSender(EmailConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void SendEmail(string receiverEmail, string subject, string emailBody, string senderEmail = null)
        {
            var smtpHost = this.configuration.SmtpServer;
            var smtpPort = this.configuration.SmtpPort;
            var username = this.configuration.SmtpUsername;
            var password = this.configuration.SmtpPassword;

            var message = new MimeMessage();
            
            message.To.Add(new MailboxAddress(string.Empty, receiverEmail));
            message.From.Add(new MailboxAddress(string.Empty, senderEmail ?? emailSender));

            message.Subject = subject;

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailBody
            };

            using var emailClient = new SmtpClient();
            emailClient.Connect(configuration.SmtpServer, configuration.SmtpPort, true);
            emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
            emailClient.Authenticate(configuration.SmtpUsername, configuration.SmtpPassword);
            emailClient.Send(message);
            emailClient.Disconnect(true);
        }
    }
}