namespace btg_testes_auto.Notification
{
    public class NotificationService
    {
        private readonly IEmailService _emailService;

        public NotificationService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public bool SendNotification(string recipient, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return false; // Se a mensagem estiver vazia, não envia o e-mail
            }

            try
            {
                return _emailService.SendEmail(recipient, "Notification", message);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
