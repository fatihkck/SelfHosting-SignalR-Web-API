using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SelfHost.ConsoleServer.Hubs
{

    public class Product
    {
        public Product(int productId,string productName, double price)
        {
            ProductId = productId;
            Name = productName;
            Price = price;
        }

        public int ProductId { get;}
        public string Name { get; }
        public double Price { get;}
    }

    public class NotifificationHub:Hub
    {

        public ObservableCollection<Product> GetAllProducts()
        {

            var products = new ObservableCollection<Product>()
            {
                new Product(1,"Product1",20.11),
                new Product(2,"Product2",50),
                new Product(3,"Product3",70.21),
                new Product(4,"Product4",90.21),

            };


            return products;
        }

        public void ServerTime()
        {
            //do
            //{
                Console.WriteLine($"Connection from {Context.ConnectionId} time : {DateTime.UtcNow:T}");
                Clients.All.displayTime($"{DateTime.UtcNow:T}");
                Thread.Sleep(TimeSpan.FromSeconds(1));

            //} while (true);
            
        }
    }
}
