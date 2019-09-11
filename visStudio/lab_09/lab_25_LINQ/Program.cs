using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_25_LINQ
{
    class Program
    {
        static List<Customer> customers;
        static List<Order> orders;
        static List<Order_Detail> orderDetail;
        static List<Product> products;
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("We are in debugging mode!");
            System.Threading.Thread.Sleep(2000);
#endif      
            
            //LINQ SIMPLE QUERY
            using (var db = new NorthwindEntities())
            {
                //customers = db.Customers.ToList();
                orders = db.Orders.ToList();
                orderDetail = db.Order_Details.ToList();

                var output1 = (from Customer in db.Customers select Customer).ToList();
                Console.WriteLine("\n\nTrivial LINQ Query");
                output1.ForEach(c => { Console.WriteLine($"{c.CustomerID}"); });

                var LINQwhere =
                        from Customer in db.Customers
                        where Customer.City == "London" || Customer.City == "Berlin"
                        select Customer;

                //LINQwhere.ToList().ForEach(c => Console.WriteLine($"Customer ID: {c.CustomerID, -10} Name: {c.ContactName, -30}"));

                PrintCustomers(LINQwhere.ToList());

                Console.WriteLine("\n\nOrder By Customer Name\n");
                var LINQOrderBy = (from Customer in db.Customers
                                   where Customer.City == "London"
                                   orderby Customer.ContactName descending
                                   select Customer).ToList();

                PrintCustomers(LINQOrderBy);

                Console.WriteLine("\n\nLambda has OrderBy...ThenBy\n");
                var LINQOrderByThenBy = db.Customers.Where(c => c.City == "London" || c.City == "Berlin" || c.City == "Madrid")
                    .OrderBy(c => c.City)
                    .ThenBy(c => c.ContactName).ToList();

                PrintCustomers(LINQOrderByThenBy);

                Console.WriteLine("\n\nCreating a custom output object\n");
                var customObject =
                    from c in db.Customers
                    where c.City == "Madrid"
                    join order in db.Orders on c.CustomerID
                    equals order.CustomerID
                    select new
                    {
                        Name = c.ContactName,
                        OrderID = order.OrderID,
                        OrderDate = order.OrderDate,
                        order.ShipCity
                    };

                //Manual Print
                customObject.ToList().ForEach(item => Console.WriteLine($"{item.Name, -30}{item.OrderDate:dd/MM/yyyy}\tOrder ID:{item.OrderID, -10}{item.ShipCity}"));

                Console.WriteLine("\n\nJoining Orders to Customers Using Lambda\n");
                //slick version, print only

                //  select all orders and put it in a list.
                //  before list is created, filter it.
                //  run through the list and for every order, find the customer (joined by customerID) for this table where the city is Madrid
                db.Orders.Where(c=> c.Customer.City == "Madrid").ToList().ForEach(c =>
                {
                    Console.WriteLine($"{c.Customer.ContactName,-30}{c.Customer.City,-15}{c.OrderID, -10}{c.OrderDate:dd/MM/yyyy}");
                });

                Console.WriteLine("\n\nJOINING THREE TABLES Using Lambda\n");

                db.Order_Details.Where(c => c.Order.Customer.City == "Madrid").ToList().ForEach(c =>
                {
                    Console.WriteLine($"|{c.Order.Customer.ContactName,-30}|{c.Order.Customer.City,-15}|{c.OrderID,-10}|{c.Order.OrderDate:dd/MM/yyyy}|\t{c.Product.ProductName,-35}|{c.ProductID}");
                });
            }
            Console.ReadLine();
        }

        #region PrintBlock
        //PrintCustomers
        static void PrintCustomers(List<Customer> customers)
        {
            customers.ForEach(c => Console.WriteLine($"ID: {c.CustomerID, -10}Name: {c.ContactName, -20}City: {c.City, -10}Country: {c.Country, -10}"));
        }
        #endregion PrintBlock
    }
}
