using SportsPro.Data;
using SportsPro.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsPro.BLL
{
   public class CustomerManager
    {
        //This method return list of customers
        public static IList<Customer> GetAll()
        {
            var context = new SportsProContext();
            var customers = context.Customers.ToList();
            return customers;
        }


        //Method to get only key value items to be populated in the dropdown lists
        public static IList GetCustomerAsKeyValuePairs()
        {
            var context = new SportsProContext();
            var customers = context.Customers.Select(c => new
            {
                Value = c.CustomerID,
                Text = c.FullName
            }).ToList();
            return customers;
        }

        //This method to add customer  to the database
        public static void Add(Customer customer)
        {
            var context = new SportsProContext();
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        //This method to find customer to the database
        public static Customer Find(int id)
        {
            var context = new SportsProContext();
            var customer = context.Customers.Find(id);
            return customer;
        }

        //This method to update customer to the database
        public static void UpdateCustomer(Customer customer)
        {
            var context = new SportsProContext();
            var originalCustomer = context.Customers.Find(customer.CustomerID);
            originalCustomer.FirstName = customer.FirstName;
            originalCustomer.LastName = customer.LastName;
            originalCustomer.Address = customer.Address;
            originalCustomer.City = customer.City;
            originalCustomer.State = customer.State;
            originalCustomer.PostalCode = customer.PostalCode;
            originalCustomer.Country = customer.Country;
            originalCustomer.Email = customer.Email;
            originalCustomer.Phone = customer.Phone;
            context.SaveChanges();
        }

        //This method to delete customer to the database
        public static void DeleteCustomer(Customer customer)
        {
            var context = new SportsProContext();
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
    }
}
