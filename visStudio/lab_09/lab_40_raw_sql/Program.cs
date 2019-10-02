using System;
using System.Data.Sql;
using System.Data.SqlClient;

namespace lab_40_raw_sql
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Northwind;
            Persist Security Info=True; User ID=SA; Password=Passw0rd2018";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);
            }
        }
    }
}
