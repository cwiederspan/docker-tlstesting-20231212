using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checking settings...");
            string connectionString = Environment.GetEnvironmentVariable("DB_CONN_STR");
            if (string.IsNullOrEmpty(connectionString) == true) {
                Console.WriteLine("You must set an ENV named DB_CONN_STR with your connection string!");
                return;
            }
            else {
                Console.WriteLine("Connection string found.");
            }

            string query = "SELECT OrderID, CustomerID FROM dbo.Orders;";

            Console.WriteLine("Running a query against Orders database table...");

            using (SqlConnection connection = new SqlConnection(connectionString)) {

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {

                    while (reader.Read()) {
                        Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
