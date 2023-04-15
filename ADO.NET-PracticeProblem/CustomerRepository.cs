using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO.NET_PracticeProblem
{
    public class CustomerRepository
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PracticeProblem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection sqlConnection = null;
        public static void GetAllCustomers()
        {
            try
            {
                CustomerDetails details = new CustomerDetails();
                sqlConnection = new SqlConnection(connectionString);
                string query = "select * from Customer";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Connections is established successfully.....");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
