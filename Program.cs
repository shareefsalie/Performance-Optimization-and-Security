using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LargeDatasetProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the dataset from a CSV file
            List<Customer> customers = LoadCustomersFromCSV("customers.csv");

            // Filter customers based on certain criteria
            List<Customer> filteredCustomers = FilterCustomers(customers);

            // Display filtered customers
            foreach (var customer in filteredCustomers)
            {
                Console.WriteLine($"{customer.Name}, {customer.Email}");
            }
        }

        static List<Customer> LoadCustomersFromCSV(string filePath)
        {
            List<Customer> customers = new List<Customer>();

            using (var reader = new StreamReader(filePath))


            {
                // header line
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    // CSV format: Name,Email,Address,PhoneNumber

                    customers.Add(new Customer
                    {
                        Name = values[0],
                        Email = values[1],
                        Address = values[2],
                        PhoneNumber = values[3]
                    });
                }
            }

            return customers;
        }

        static List<Customer> FilterCustomers(List<Customer> customers)
        {
            // filter: Select customers whose address contains "South Africa"
            return customers.Where(c => c.Address.Contains("South Africa")).ToList();
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
