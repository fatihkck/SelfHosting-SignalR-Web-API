using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost.ConsoleClient
{


    public class ProductView
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Program
    {

        static void RunSignalrClient()
        {
            string uri = "http://localhost:8983/";

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

                var products = proxy.Invoke<ObservableCollection<ProductView>>("GetAllProducts").Result;

                products.ToList().ForEach(p => Console.WriteLine($"Product : {p.ProductId} {p.Name} {p.Price}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        static string[] RunWebApi()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = client.GetAsync("http://localhost:8983/api/product").Result;

            var result = message.Content.ReadAsAsync<string[]>().Result;

            if (message.IsSuccessStatusCode)
            {
                return result;
            }

            return null;

        }

        static void Main(string[] args)
        {

            Console.WriteLine("press enter to start signalr");
            Console.ReadLine();
            RunSignalrClient();


            Console.WriteLine("press enter to start web api");
            Console.ReadLine();
            RunWebApi().ToList().ForEach(p => Console.WriteLine($"{p}"));
            Console.ReadLine();
        }
    }
}
