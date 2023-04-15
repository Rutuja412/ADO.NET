using System;

namespace ADO.NET_PracticeProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ADO.NET Practice Problem");
           // CustomerRepository.GetAllCustomers();
           // Console.WriteLine("------------");
           //CustomerDetails person = new CustomerDetails();
           // person.CustomerName = "Vedika";
           // person.Address = "Chennai";
           // person.PhoneNumber = "1234567890";
           // person.Country = "Iran";
           // person.Salary = "35000";
           // person.Pincode = "456783";
           // CustomerRepository.AddCustomer(person);
            
            Console.WriteLine("-------------------------------------------");
            CustomerRepository.GetAllCustomers();
            Console.WriteLine("___________________________________________________________________");
            CustomerDetails person2 = new CustomerDetails();
            person2.CustomerID = 5;
            person2.CustomerName = "Sam";
            CustomerRepository.DeleteEmployee(person2);
            Console.WriteLine("-------------------------------------------");
            CustomerRepository.GetAllCustomers();
            Console.WriteLine("___________________________________________________________________");
        }
    }
}
