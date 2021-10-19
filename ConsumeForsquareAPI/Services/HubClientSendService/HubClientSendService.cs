using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Services
{
    public class HubClientSendService : IHubClientSendService
    {
        private HubConnection hubConnection;

        public HubClientSendService()
        {
            hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:44381/reqHub").Build();
            hubConnection.StartAsync().Wait();
        }
        public async Task ConnectAsync(string url)
        {
            hubConnection = new HubConnectionBuilder().WithUrl(url).Build();
            await hubConnection.StartAsync();

        }

        public async Task SendMessage(string message)
        {
            await hubConnection.InvokeAsync("SendRequestInfo", message);
        }
    }
}
