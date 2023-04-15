using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
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
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        details.CustomerID = Convert.ToInt32(reader["CustomerID"] == DBNull.Value ? default : reader["CustomerID"]);
                        details.CustomerName = reader["CustomerName"] == DBNull.Value ? default : reader["CustomerName"].ToString();
                      
                        details.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                        details.PhoneNumber = reader["PhoneNumber"] == DBNull.Value ? default : reader["PhoneNumber"].ToString();

                        details.Country = reader["Country"] == DBNull.Value ? default : reader["Country"].ToString();
                        details.Salary = reader["Salary"] == DBNull.Value ? default : reader["Salary"].ToString();
                        details.Pincode = reader["Pincode"] == DBNull.Value ? default : reader["Pincode"].ToString();
                      
                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", details.CustomerID, details.CustomerName, details.Address, details.PhoneNumber, details.Country, details.Salary, details.Pincode);
                    }
                }
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
