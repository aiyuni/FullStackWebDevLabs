using System;
using System.Collections.Generic;
using System.Linq;
using Lab1.Models.AW;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            AdventureWorksContext dbContext = new AdventureWorksContext();

            List<Location> locationList = dbContext.Location.ToList();

            foreach (Location loc in locationList)
            {
                Console.WriteLine(loc.ToString());
            }

            List<Product> productList = dbContext.Product.OrderByDescending(a => a.StandardCost).Take(5).ToList();

            foreach (Product product in productList)
            {
                Console.WriteLine(product);
            }

            List<Customer> salesCustomers = dbContext.Customer.Where(c => c.PersonId != null).ToList();
            //List<Customer> salesCustomers = dbContext.Customer.Select(c => new {c.CustomerId, c.PersonId, c.Person});

            List<Person> salesPersons = new List<Person>();
            foreach (Customer saleCustomer in salesCustomers)
            {
                Person salePerson = dbContext.Person.Find(saleCustomer.PersonId);
                salesPersons.Add(salePerson);
                Console.WriteLine("Sales customer name is: " + salePerson.FirstName + " " + salePerson.MiddleName +
                                  salePerson.LastName);
            }

            Console.WriteLine();
            


        }


    }
}
