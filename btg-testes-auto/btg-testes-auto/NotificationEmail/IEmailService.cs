namespace btg_testes_auto.Notification
{
    public interface IEmailService
    {
        bool SendEmail(string to, string subject, string body);
    }
}
