using Microsoft.EntityFrameworkCore;
using SportsPro.Data;
using SportsPro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsPro.BLL
{
    public class RegistrationManager
    {
        //this method return list of registrations
        public static IList<Registration> GetAll()//including the other objects data(Customer and Product)
        {
            var context = new SportsProContext();
            var registrations = context.Registrations.Include(r => r.Customer)
                                             .Include(inc => inc.Product).ToList();
            return registrations;
        }

        //this method to add registration to database
        public static void Add(Registration registration)
        {
            var context = new SportsProContext();
            context.Registrations.Add(registration);
            context.SaveChanges();
        }

        //this method to find registration in the database
        public static Registration Find(int id)
        {
            var context = new SportsProContext();
            var currentRegistration = context.Registrations.Find(id);
            return currentRegistration;
        }



        //this method to update registration in the database
        public static void UpdateReg(Registration registration)
        {
            var context = new SportsProContext();
            var originalRegistration = context.Registrations.Find(registration.RegistrationID);
            originalRegistration.CustomerID = registration.CustomerID;
            originalRegistration.ProductID = registration.ProductID;
           
            context.SaveChanges();
        }

        //this method to delete registration in the database
        public static void DeleteReg(Registration registration)
        {
            var context = new SportsProContext();
            context.Registrations.Remove(registration);
            context.SaveChanges();
        }

    }
}
