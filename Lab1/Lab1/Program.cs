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
            List<Customer> sc = salesCustomers.Where(p => p)
            //List<Customer> salesCustomers = dbContext.Customer.Select(c => new {c.CustomerId, c.PersonId, c.Person});
            List<Person> salesPersons = new List<Person>();
            //foreach (Customer saleCustomer in salesCustomers)
            //{
            //    Person salePerson = dbContext.Person.Find(saleCustomer.PersonId);
            //    salesPersons.Add(salePerson);
            //    Console.WriteLine("Sales customer name is: " + salePerson.FirstName + " " + salePerson.MiddleName +
            //                      salePerson.LastName);

            //}

            var cl = dbContext.Customer.Where(c => c.Person != null).Select(p => new
            {
                p.CustomerId, p.Person.FirstName, p.Person.LastName
            });

            foreach (var item in cl)
            {
                Console.WriteLine(item.FirstName + ", " + item.LastName);
            }

            Console.WriteLine();
            


        }


    }
}
