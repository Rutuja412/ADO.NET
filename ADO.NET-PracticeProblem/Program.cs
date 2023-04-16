using System;

namespace ADO.NET_PracticeProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ADO.NET Practice Problem");
            Console.WriteLine("Please select given options");
            Console.WriteLine("1.Get all Customers\n" + "2.Add new customer data\n" + "3. Delete customer \n" + "4.Exit\n");


            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    CustomerRepository.GetAllCustomers();
                    break;
                case 2:
                    
                    CustomerDetails person = new CustomerDetails();
                    person.CustomerName = "Pooja";
                    person.Address = "Ahmadabad";
                    person.PhoneNumber = "1234567890";
                    person.Country = "India";
                    person.Salary = "67000";
                    person.Pincode = "45674";
                    CustomerRepository.AddCustomer(person);
                    Console.WriteLine("-----------------------");
                    CustomerRepository.GetAllCustomers();

                    break;
                case 3:
                    Console.WriteLine("-------------------------------------------");
                    CustomerRepository.GetAllCustomers();
                    Console.WriteLine("___________________________________________________________________");
                    CustomerDetails person2 = new CustomerDetails();
                    person2.CustomerID = 8;
                    person2.CustomerName = "Pooja";
                    CustomerRepository.DeleteEmployee(person2);
                    Console.WriteLine("-------------------------------------------");
                    CustomerRepository.GetAllCustomers();
                    break;
            }


        }
    }
}
