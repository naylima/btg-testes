namespace btg_testes_auto.NotificationMessage
{
    public class NotificationMessageService
    {
        private readonly IMessageService _messageService;

        public NotificationMessageService(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public bool NotifyUsers(List<Notification> notifications)
        {
            bool allSent = true;

            foreach (var notification in notifications)
            {
                if (!_messageService.SendMessage(notification.UserId, notification.Message))
                {
                    allSent = false;
                    break; // Se uma mensagem falhar, interrompe a notificação
                }
            }

            return allSent;
        }
    }
}
