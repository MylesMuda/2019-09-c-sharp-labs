using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_24_Northwind
{
    class Program
    {
        static List<Product> products;
        static List<Category> categories;
        static void Main(string[] args)
        {
            using(var db = new NorthwindEntities())
            {
                products = db.Products.ToList();
                categories = db.Categories.ToList();
            }

            products.ForEach(p =>
            {
                Console.WriteLine($"ID: {p.ProductID,-10} Product: {p.ProductName,-35} Price: {p.UnitPrice,-10}");
            });
            Console.WriteLine("\n");
            categories.ForEach(c =>
            {
                Console.WriteLine($"ID: {c.CategoryID, -10} Name: {c.CategoryName,-38} Description: {c.Description, -10}");
            });
            Console.ReadLine();
        }
    }
}
