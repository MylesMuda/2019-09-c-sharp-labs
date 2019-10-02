using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;

namespace lab_40_raw_sql
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        //static string connnectionString = @"Data Source=localhost;Initial Catalog=Northwind;
        //                                  Persist Security Info=True; User ID=SA; Password=Passw0rd2018";
        static string connectionString2 = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;";
        static void Main(string[] args)
        {
            InsertCustomer();
            UpdateCustomer();
            DeleteCustomer();
            GetCustomers();
        }

        static void GetCustomers()
        {
            //string connectionString = @"Data Source=localhost;Initial Catalog=Northwind;
            //Persist Security Info=True; User ID=SA; Password=Passw0rd2018";

            //string connectionString2 = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind;";

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    Console.WriteLine(connection.State);
            //}

            using (var connection2 = new SqlConnection(connectionString2))
            {
                connection2.Open();
                Console.WriteLine(connection2.State);

                string sqlQuery01 = "select * from customers order by CompanyName";
                using (var sqlcommand = new SqlCommand(sqlQuery01, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var CustomerID = reader["CustomerID"].ToString();
                        var CompanyName = reader["CompanyName"].ToString();
                        var ContactName = reader["ContactName"].ToString();
                        var City = reader["City"].ToString();
                        var Country = reader["Country"].ToString();
                        var customer = new Customer(CustomerID, CompanyName, ContactName, City, Country);

                        customers.Add(customer);
                    }
                }

                Console.WriteLine($"-----------------------\nREADING ALL NORTHWIND CUSTOMERS\n----------------------\n");
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-15}{c.ContactName,-25}" +
                    $"{c.CompanyName,-38}{c.City,-16}{c.Country}"));
                Console.WriteLine($"\nThere are {customers.Count} customers.");
            }
        }

        static void InsertCustomer()
        {
            using(var connection = new SqlConnection(connectionString2))
            {
                connection.Open();
                var FixedCustomer = new Customer(GetRandomID(), "COOL INC.", "BOSS MYLES", "LONDON", "UNITED KINGDOM");
                var sqlString = $"INSERT INTO CUSTOMERS (CustomerID,CompanyName,ContactName,City,Country)" +
                    $"VALUES ('{FixedCustomer.CustomerID}','{FixedCustomer.CompanyName}','{FixedCustomer.ContactName}','{FixedCustomer.City}','{FixedCustomer.Country}')";
                
                using(var command = new SqlCommand(sqlString, connection))
                {
                    int affected = command.ExecuteNonQuery();
                    Console.WriteLine($"{affected} rows affected");
                }

                //insert using parameters
                //use parameters when taking values from (eg screen)
                //generate new ID
                var randomID = GetRandomID();
                Console.WriteLine($"New ID is {randomID}");
                var sqlString2 = $"INSERT INTO CUSTOMERS (CustomerID,CompanyName,ContactName,City,Country)" +
                    $"VALUES (@CustomerID, @CompanyName, @ContactName, @City, @Country)";

                using (var insertWithParameters = new SqlCommand(sqlString2, connection))
                {
                    insertWithParameters.Parameters.AddWithValue("@CustomerID", randomID);
                    insertWithParameters.Parameters.AddWithValue("@CompanyName", "Sam & Co.");
                    insertWithParameters.Parameters.AddWithValue("@ContactName", "Samuel");
                    insertWithParameters.Parameters.AddWithValue("@City", "England");
                    insertWithParameters.Parameters.AddWithValue("@Country", "Nevada");
                    var sqlReader = insertWithParameters.ExecuteReader();
                }
                    
            }
        }

        static string GetRandomID()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZABCDEFGHIJKLMNOPQRSTUVXYZ";
            string ID = "";
            Random r = new Random();

            for (int i = 0; i < 5; i++)
            {
                ID += alphabet[r.Next(0, alphabet.Length - 1)];
            }

            return ID;

            
        }

        static void UpdateCustomer()
        {
            using(var connection = new SqlConnection(connectionString2))
            {
                connection.Open();
                var customerToUpdate = "ALFKI";
                var sqlUpdate = $"UPDATE Customers SET City='Paris' WHERE CustomerID='{customerToUpdate}'";
                using (var sqlCommand = new SqlCommand(sqlUpdate, connection))
                {
                    int affected = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Number of records updated : {affected}");
                }
            }
        }
        
        static void DeleteCustomer()
        {
            using(var connection = new SqlConnection(connectionString2))
            {
                connection.Open();
                var customerToDelete = "MTAFT";
                var sqlDelete = $"DELETE FROM Customers WHERE CustomerID = '{customerToDelete}'";
                using(var command = new SqlCommand(sqlDelete, connection))
                {
                    int affected = command.ExecuteNonQuery();
                    Console.WriteLine($"Number of records deleted : {affected}");
                }
            }    
        }



    }

    public partial class Customer
    { 
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public Customer(string customerID, string companyName, string contactName, string city, string country)
        {
            this.CustomerID = customerID;
            this.CompanyName = companyName;
            this.ContactName = contactName;
            this.City = city;
            this.Country = country;
        }
    }
}
