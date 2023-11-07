using Microsoft.AspNetCore.SignalR;

namespace DatingApp_Server.ChatHub
{
    public sealed class ChatHub : Hub<IChatClient>
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.ReceiveMessage($"{Context.ConnectionId}: {message}");
        }
    }
}
