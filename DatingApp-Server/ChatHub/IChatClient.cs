namespace DatingApp_Server.ChatHub
{
    public interface IChatClient
    {
        Task ReceiveMessage(string message);
    }
}
