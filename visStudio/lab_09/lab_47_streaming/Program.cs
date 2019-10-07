using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace lab_47_streaming
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Customer> customersFromXML = new List<Customer>();
        static List<Customer> customersFromWeb = new List<Customer>();
        static void Main(string[] args)
        {
            var customer01 = new Customer()
            {
                CustomerID = "ALFKI",
                ContactName = "Fried",
                CompanyName = "Sparta",
                City = "Berlin"
            };
            var customer02 = new Customer()
            {
                CustomerID = "ALFKE",
                ContactName = "Friedo",
                CompanyName = "Spartae",
                City = "Berlina"
            };
            var customer03 = new Customer()
            {
                CustomerID = "ALFKO",
                ContactName = "Friedy",
                CompanyName = "Spartog",
                City = "Berlino"

            };
            customers.Add(customer01);
            customers.Add(customer02);
            customers.Add(customer03);

            //List
            //Serialise to XML, JSON and Binary
            var fromatter = new SoapFormatter();
            //Save to file, stream to file
            using (var stream = new FileStream("data.xml", FileMode.Create, FileAccess.Write))
            {
                fromatter.Serialize(stream, customers);
            }

            Console.WriteLine(File.ReadAllText("data.xml"));
            //reverse process => stream back and de-serialise data

            using(var reader = File.OpenRead("data.xml"))
            {
                customersFromXML = fromatter.Deserialize(reader) as List<Customer>;
            }
            //deserialise to list
            Console.WriteLine($"\n\nCustomers from XML\n\n");
            customersFromXML.ForEach(c => { Console.WriteLine($"{c.CustomerID,-15}{c.ContactName,-20}{c.CompanyName,-20}{c.City}"); });

            //repeat and simulate streaming from the internet
            //For the sake of time, easy version, sync not async

            var getHMTLdata = WebRequest.Create("https://raw.githubusercontent.com/MylesMuda/data/master/Customers.xml");

            getHMTLdata.Proxy = null;

            //get web response from request to that url
            using(var webResponse = getHMTLdata.GetResponse())
            {
                //stream the data in because it could be a large file and take a long time
                //possibly come down in blocks
                using(var webstream = webResponse.GetResponseStream())
                {
                    //we get the web stream above; now get a new stream to stream data to local file system for processing
                    using (var filestream = File.Create("CustomersFromWeb.xml"))
                    {
                        webstream.CopyTo(filestream);
                    }
                }
            }

            using (var reader2 = File.OpenRead("CustomersFromWeb.xml"))
            {
                customersFromWeb = fromatter.Deserialize(reader2) as List<Customer>;
            }
            //deserialise to list
            Console.WriteLine($"\n\nCustomers from Web\n\n");
            customersFromWeb.ForEach(c => { Console.WriteLine($"{c.CustomerID,-15}{c.ContactName,-20}{c.CompanyName,-20}{c.City}"); });
        }
    }
    [Serializable]
    class Customer
    {
        //[NonSerialized]
        private string NINO;
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }

        public Customer()
        {
            this.NINO = "ABCD";
        }
    }
}
