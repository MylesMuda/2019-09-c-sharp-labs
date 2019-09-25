using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_36_API_Northwind.Controllers
{
    public class CustomerController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        public static List<Customer> customers = new List<Customer>();

        public List<Customer> GetCustomers()
        {
            var c = new Customer()
            {
                CustomerID = "Myles123",
                ContactName = "Myles",
                CompanyName = "Me go work"
            };
            customers.Add(c);
            return customers;
        }

        public ActionResult AnotherPage()
        {
            ViewBag.Title = "Another Page";

            return View("Index");
        }

        public ActionResult FinalPage()
        {
            ViewBag.OtherData = "Here is something else to show";
            ViewBag.MyList = new List<String>() { "one", "two", "three" };
            return View();
        }



        public ActionResult Customers()
        {
            using (var db = new NorthwindEntities())
            {
               customers = db.Customers.ToList();
            }
            ViewBag.customers = customers;
            return View();
        }
    }
}
