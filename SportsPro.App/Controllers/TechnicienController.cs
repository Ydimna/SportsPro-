using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsPro.BLL;
using SportsPro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.App.Controllers
{
    [Authorize(Roles = "Admin")]
    
    public class TechnicienController : Controller
    {

        private IHttpContextAccessor http { get; set; }
        private TechnicienManager data { get; set; }

        // GET: TechnicianController
        public ActionResult Index()
        {
            var technicien = TechnicienManager.GetAll();
            return View(technicien);
        }

      

        // GET: TechnicienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnicienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Technician technician)
        {
            try
            {
                TechnicienManager.Add(technician);
                TempData["message"] = $"{technician.Name} was successfully added.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TechnicienController/Edit/5
        public ActionResult Edit(int id)
        {
            var technician = TechnicienManager.Find(id);
            return View(technician);
        }

        // POST: TechnicienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Technician technician)
        {
            try
            {
                TechnicienManager.UpdateTechnician(technician);
                TempData["message"] = $"{technician.Name} was successfully updated.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TechnicienController/Delete/5
        public ActionResult Delete(int id)
        {
            var technician = TechnicienManager.Find(id);
            return View(technician);
        }

        // POST: TechnicienController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Technician technicien)
        {
            try
            {
                TechnicienManager.DeleteTechnicien(technicien);
                //TempData["message"] = $"{technicien.Name} was successfully deleted.";
                TempData["message"] = $"The selected was successfully deleted.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
