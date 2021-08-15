namespace E_Store.Business.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(string receiverEmail, string subject, string emailBody, string senderEmail = null);
    }
}