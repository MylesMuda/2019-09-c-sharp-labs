using System;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace lab_48_read_API
{
    class Program
    {
        static string URL = "https://localhost:44390/api/products";
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            Console.WriteLine($"Is local network live? : {NetworkInterface.GetIsNetworkAvailable()}");
            Console.WriteLine($"Can we reach the internet? : {IsNetworkLive()}");

            GetAPIDataAsync();
            Console.ReadLine();
        }

        public static bool IsNetworkLive()
        {
            // DO SOMETHING TO CHECK IF THE NETWORK CONNECTION IS OKAY FIRST
            // MANY WAYS TO DO THIS - TRY A PING
            var pingGoogle = new Ping();
            var pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
            string data = "abcdefghijklmnopqrstuvwxyz";
            var timeOut = 120;
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            // send 4 pings
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Loop {i}\n");
                var reply = pingGoogle.Send("8.8.8.8", timeOut, buffer, pingOptions);
                if(reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            return false;
        }

        static async void GetAPIDataAsync()
        {
            using(var client = new HttpClient())
            {
                var s = new Stopwatch();
                s.Start();
                var JSONString = await client.GetStringAsync(URL);

                //convert to an object (deserialising)
                //using this newtonsoft library to do this
                products = JsonConvert.DeserializeObject<List<Product>>(JSONString);
                Console.WriteLine($"Query took {s.ElapsedMilliseconds} milliseconds");
                PrintProducts();
            }
        }

        static void PrintProducts()
        {
            products.ForEach(p =>
            {
                Console.WriteLine($"{p.ProductID},{p.ProductName}");
            });
        }

    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

}
