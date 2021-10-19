using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Hubs
{
    public class RequestHub : Hub
    {
        public Task SendRequestInfo(string request)
        {
            return Clients.All.SendAsync("RecieveRequest", request);
        }
    }
}
