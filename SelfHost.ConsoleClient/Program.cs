using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost.ConsoleClient
{
    class Program
    {
        static void RunSignalrClient()
        {
            string uri = "http://localhost:8989/";

            HubConnection connection = new HubConnection(uri);
            var proxy = connection.CreateHubProxy("notifificationHub");

            try
            {
                connection.Start().Wait();
                proxy.On<string>("displayTime", time =>
                 {
                     Console.Clear();
                     Console.WriteLine(time);
                 });

                proxy.Invoke("ServerTime");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("press enter to start signalr");
            Console.ReadLine();
            RunSignalrClient();
            Console.ReadLine();
        }
    }
}
