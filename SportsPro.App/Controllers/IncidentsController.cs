using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsPro.BLL;
using SportsPro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.App.Controllers
{
    [Authorize(Roles = "Admin, Tech")]
    public class IncidentsController : Controller
    {
        
        private IHttpContextAccessor http { get; set; }
        private ProductManager data { get; set; }

        // GET: IncidentsController
        public ActionResult Index()
        {
            var incidents = IncidentManager.GetAll();
            return View(incidents);
        }

        public ActionResult Unassigned()
        {
            var incidents = IncidentManager.GetUnassigned();
            return View(incidents);
        }

        public ActionResult OpenIncidents()
        {
            var incidents = IncidentManager.GetOpen();
            return View(incidents);
        }

        // GET: IncidentsController/Details/5


        // GET: IncidentsController/Create
        public ActionResult Create()
        {
            //get the list of customers from the customer manager
            var customers = CustomerManager.GetCustomerAsKeyValuePairs();
            var listcust = new SelectList(customers, "Value", "Text");
            ViewBag.CustomerID = listcust;

            //get the list of products from the product manager
            var products = ProductManager.GetProductAsKeyValuePairs();
            var listprod = new SelectList(products, "Value", "Text");
            ViewBag.ProductID = listprod;

            //get the list of Technicians from the Technicians manager
            var technician = TechnicienManager.GetTechnicienAsKeyValuePairs();
            var listtech = new SelectList(technician, "Value", "Text");
            ViewBag.TechnicianID = listtech;
            return View();
        }

        // POST: IncidentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Incident incident)
        {
            try
            {
                IncidentManager.Add(incident);
                TempData["message"] = $"{incident.Title} incident was successfully added.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IncidentsController/Edit/5
        public ActionResult Edit(int id)
        {
            //get the list of customers from the customer manager
            var customers = CustomerManager.GetCustomerAsKeyValuePairs();
            var listcust = new SelectList(customers, "Value", "Text");
            ViewBag.CustomerID = listcust;

            //get the list of products from the product manager
            var products = ProductManager.GetProductAsKeyValuePairs();
            var listprod = new SelectList(products, "Value", "Text");
            ViewBag.ProductID = listprod;

            //get the list of Technicians from the Technicians manager
            var technician = TechnicienManager.GetTechnicienAsKeyValuePairs();
            var listtech = new SelectList(technician, "Value", "Text");
            ViewBag.TechnicianID = listtech;

            var incident = IncidentManager.Find(id);
            return View(incident);
        }

        // POST: IncidentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Incident incident)
        {
            try
            {
                IncidentManager.UpdateIncident(incident);
                TempData["message"] = $"{incident.Title} incident was successfully updated.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IncidentsController/Delete/5
        public ActionResult Delete(int id)
        {
            var incident = IncidentManager.Find(id);

            return View(incident);
        }

        // POST: IncidentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Incident incident)
        {
            try
            {
                IncidentManager.DeleteIncident(incident);
                TempData["message"] = $"The selected incident was successfully deleted.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
