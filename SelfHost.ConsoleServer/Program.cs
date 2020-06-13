using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SelfHost.ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8983/";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine($"Server started at {uri} on {DateTime.UtcNow:F}");
                Console.ReadLine();
            }

            Console.Read();
        }
    }
}
