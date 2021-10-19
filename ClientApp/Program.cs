using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44381/reqHub")
                .Build();

            connection.On("RecieveRequest", (string message) =>
            {
                Console.WriteLine(message);
            });
            connection.StartAsync().Wait();

            Console.ReadKey();
        }       
    }
}
