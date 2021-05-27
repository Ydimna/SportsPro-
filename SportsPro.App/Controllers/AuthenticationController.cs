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
    public class AuthenticationController : Controller
    {
        // GET: AuthenticationController
        public ActionResult Index()
        {
            var auth = AuthenticationManager.GetAll();
            return View(auth);
        }

       
        // GET: AuthenticationController/Create
        public ActionResult Create()
        {
            var auth = AuthenticationManager.GetAll();
            return View();
        }

        // POST: AuthenticationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Authentication  authentication)
        {
            try
            {
                AuthenticationManager.Add(authentication);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthenticationController/Edit/5
        public ActionResult Edit(int id)
        {
            var auth = AuthenticationManager.Find(id);
            return View(auth);
            
        }

        // POST: AuthenticationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Authentication authentication)
        {
            try
            {
                AuthenticationManager.Update(authentication);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthenticationController/Delete/5
        public ActionResult Delete(int id)
        {
            var authentication = AuthenticationManager.Find(id);
            return View(authentication);
        }

        // POST: AuthenticationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Authentication authentication)
        {
            try
            {
                AuthenticationManager.Delete(authentication);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
