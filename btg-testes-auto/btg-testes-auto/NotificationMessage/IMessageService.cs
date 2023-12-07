namespace btg_testes_auto.NotificationMessage
{
    public interface IMessageService
    {
        bool SendMessage(string userId, string message);
    }
}
