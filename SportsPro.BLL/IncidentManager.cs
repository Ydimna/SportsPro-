using Microsoft.EntityFrameworkCore;
using SportsPro.Data;
using SportsPro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsPro.BLL
{
    public class IncidentManager
    {
        public object Incidents { get; set; }
        public object Technicians { get; set; }
        public object Customers { get; set; }
        public object Products { get; set; }

        //This method is to retrieve a list of incidents from the database
        public static IList<Incident> GetAll()//including the other objects data(Customer and Product)
        {
            var context = new SportsProContext();
            var incidents = context.Incidents.Include(i => i.Customer)
                                             .Include(inc => inc.Product).ToList();
            return incidents;
        }

        //This method is to retrieve a list of unassigned incidents from the database
        public static IList<Incident> GetUnassigned()
        {
            var context = new SportsProContext();
            var incidents = context.Incidents.Where(i => i.TechnicianID == null)
                                             .Include(i => i.Customer)
                                             .Include(inc => inc.Product).ToList();
            return incidents;
        }

        //This method to retrieve a list of incidents to the database
        public static IList<Incident> GetOpen()
        {
            var context = new SportsProContext();
            var incidents = context.Incidents.Where(i => i.DateClosed == null)
                                             .Include(i => i.Customer)
                                             .Include(inc => inc.Product).ToList();
            return incidents;
        }

        //This method to delete the incident to the database
        public static void DeleteIncident(Incident incident)
        {
            var context = new SportsProContext();
            context.Incidents.Remove(incident);
            context.SaveChanges();
        }

        //This method to find the incident to the database
        public static Incident Find(int id)
        {
            var context = new SportsProContext();
            var currentIncident = context.Incidents.Find(id);
            return currentIncident;
        }

        //This method to Update the incident to the database
        public static void UpdateIncident(Incident incident)
        {
            var context = new SportsProContext();
            var originalIncident = context.Incidents.Find(incident.IncidentID);
            originalIncident.CustomerID = incident.CustomerID;
            originalIncident.ProductID = incident.ProductID;
            originalIncident.TechnicianID = incident.TechnicianID;
            originalIncident.Title = incident.Title;
            originalIncident.Description = incident.Description;
            originalIncident.DateOpened = incident.DateOpened;
            originalIncident.DateClosed = incident.DateClosed;
            context.SaveChanges();
        }

        //This method to add incident to the database
        public static void Add(Incident incident)
        {
            var context = new SportsProContext();
            context.Incidents.Add(incident);
            context.SaveChanges();
        }


    }
}
