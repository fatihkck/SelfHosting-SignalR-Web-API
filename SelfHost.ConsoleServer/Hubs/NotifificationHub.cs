using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SelfHost.ConsoleServer.Hubs
{
    public class NotifificationHub:Hub
    {
        public void ServerTime()
        {
            do
            {
                Console.WriteLine($"Connection from {Context.ConnectionId} time : {DateTime.UtcNow:T}");
                Clients.All.displayTime($"{DateTime.UtcNow:T}");
                Thread.Sleep(TimeSpan.FromSeconds(1));

            } while (true);
            
        }
    }
}
