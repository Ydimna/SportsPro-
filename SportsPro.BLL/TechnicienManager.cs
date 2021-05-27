using SportsPro.Data;
using SportsPro.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsPro.BLL
{
    public class TechnicienManager
    {
        //this method to return list of technicians in the database
        public static IList<Technician> GetAll()
        {
            var context = new SportsProContext();
            var technicien = context.Technicians.OrderBy(t => t.Name).ToList();
            return technicien;
        }

        //Method to get only key value items to be populated in the dropdown lists
        public static IList GetTechnicienAsKeyValuePairs()
        {
            var context = new SportsProContext();
            var technicien = context.Technicians.Select(t => new
            {
                Value = t.TechnicianID,
                Text = t.Name
            }).ToList();
            return technicien;
        }

        //this method to delete  technician from the database
        public static void DeleteTechnicien(Technician technicien)
        {
            var context = new SportsProContext();
            context.Technicians.Remove(technicien);
            context.SaveChanges();
        }

        public static Technician Find(int id)
        {
            var context = new SportsProContext();
            var technicien = context.Technicians.Find(id);
            return technicien;
        }

        public static void Add(Technician technician)
        {
            var context = new SportsProContext();
            context.Technicians.Add(technician);
            context.SaveChanges();
        }

        public static void UpdateTechnician(Technician technician)
        {
            var context = new SportsProContext();
            var originalTechnician = context.Technicians.Find(technician.TechnicianID);
            originalTechnician.Name = technician.Name;
            originalTechnician.Email = technician.Email;
            originalTechnician.Phone = technician.Phone;
            context.SaveChanges();
        }

    }
}
