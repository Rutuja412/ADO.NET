using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace ADO.NET_PracticeProblem
{
    public class CustomerRepository
    {
        //Store the connection string in the ConnectionString variable
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PracticeProblem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection sqlConnection = null;
        public static void GetAllCustomers()
        {
            try
            {
                CustomerDetails details = new CustomerDetails();
                //Create the SqlConnection object
                sqlConnection = new SqlConnection(connectionString);
                string query = "select * from Customer";
                //Create the SqlCommand object by passing the query and connection object as parameters
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                //Open the Connection
                sqlConnection.Open();
                // Executing the Stored Procedure using ExecuteReader method
                //SqlDataReader requires an active and open connection
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Connections is established successfully.....");
                if (reader.HasRows)
                //Read the data from the SqlDataReader 
                {
                    //Read() method will returns true as long as data is there in the SqlDataReader
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
        public static void AddCustomer(CustomerDetails details)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                //Create the SqlCommand object by passing the stored procedure name and connection object as parameters
                SqlCommand command = new SqlCommand("dbo.spAddNewCustomer", sqlConnection);
                //Specify the command type as Stored Procedure
                command.CommandType = CommandType.StoredProcedure;
                //Open the Connection
                sqlConnection.Open();
                command.Parameters.AddWithValue("@CustomerName", details.CustomerName);
                command.Parameters.AddWithValue("@Address", details.Address );
                command.Parameters.AddWithValue("@PhoneNumber", details.PhoneNumber);
                command.Parameters.AddWithValue("@Country", details.Country);
                command.Parameters.AddWithValue("@Salary", details.Salary);
                command.Parameters.AddWithValue("@Pincode", details.Pincode);
                int num = command.ExecuteNonQuery();
                if (num != 0)
                    Console.WriteLine("Customer Added Successfully");
                else
                    Console.WriteLine("Something went Wrong");
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
        public static void DeleteEmployee(CustomerDetails details)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("dbo.spDeleteCustomer", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                command.Parameters.AddWithValue("@CustomerName", details.CustomerName);
                command.Parameters.AddWithValue("@CustomerId", details.CustomerID);
                int num = command.ExecuteNonQuery();
                if (num != 0)
                    Console.WriteLine("Customer Delete Successfully");
                else
                    Console.WriteLine("Something went Wrong");
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
