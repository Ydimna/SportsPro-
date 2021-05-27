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
    [Authorize(Roles = "Admin")]
    public class RegistrationController : Controller
    {
        private IHttpContextAccessor http { get; set; }
        // GET: RegistrationController
        public ActionResult Index()
        {
            // return the list of registrations from the registrationManager
            var registrations = RegistrationManager.GetAll();
            return View(registrations);
        }

     

        // GET: RegistrationController/Create
        public ActionResult Create()
        {
            // return the list of customers from the customerManager
            var customers = CustomerManager.GetCustomerAsKeyValuePairs();
            var listcust = new SelectList(customers, "Value", "Text");
            ViewBag.CustomerID = listcust;

            // return the list of products from the ProdyctManager
            var products = ProductManager.GetProductAsKeyValuePairs();
            var listprod = new SelectList(products, "Value", "Text");
            ViewBag.ProductID = listprod;
            return View();
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration registration)
        {
            try
            {
                // add registration by calling the method from   the RegistrationManager
                RegistrationManager.Add(registration);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            // return the list of customers from the customerManager
            var customers = CustomerManager.GetCustomerAsKeyValuePairs();
            var listcust = new SelectList(customers, "Value", "Text");
            ViewBag.CustomerID = listcust;

            // return the list of products from the ProductManager
            var products = ProductManager.GetProductAsKeyValuePairs();
            var listprod = new SelectList(products, "Value", "Text");
            ViewBag.ProductID = listprod;

            // return the list of registrations from the RegistrationManager
            var registration = RegistrationManager.Find(id);
            return View(registration);
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Registration registration)
        {
            try
            {
                RegistrationManager.UpdateReg(registration);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            var registration = RegistrationManager.Find(id);
            return View(registration);
        }

        // POST: RegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Registration registration)
        {
            try
            {
                RegistrationManager.DeleteReg(registration);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
