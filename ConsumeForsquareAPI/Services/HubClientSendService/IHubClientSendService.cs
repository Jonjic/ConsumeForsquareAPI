using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeForsquareAPI.Services
{
    public interface IHubClientSendService
    {
        public Task ConnectAsync(string url);
        public Task SendMessage(string message);
        
    }
}
