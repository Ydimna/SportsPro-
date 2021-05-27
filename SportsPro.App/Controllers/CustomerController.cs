using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsPro.BLL;
using SportsPro.Domain;

namespace SportsPro.App.Controllers
{
    [Authorize(Roles = "Admin")]//Only admin can add customers
    public class CustomerController : Controller
    {

        private IHttpContextAccessor http { get; set; }
        private ProductManager data { get; set; }

        // GET: CustomerController
        public ActionResult Index()
        {
            var customers = CustomerManager.GetAll();

            return View(customers);
        }



        // GET: CustomerController/Create
        
        public ActionResult Create()
        {
            var countries = CountryManager.GetProductAsKeyValuePairs();
            var list = new SelectList(countries, "Value", "Text");
            ViewBag.CountryID = list;
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                CustomerManager.Add(customer);
                TempData["message"] = $"{customer.FullName} was successfully added.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var countries = CountryManager.GetProductAsKeyValuePairs();
            var list = new SelectList(countries, "Value", "Text");
            ViewBag.CountryID = list;
            var customer = CustomerManager.Find(id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                CustomerManager.UpdateCustomer(customer);
                TempData["message"] = $"{customer.FullName}  was successfully updated.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = CustomerManager.Find(id);

            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customer customer)
        {
            try
            {
                CustomerManager.DeleteCustomer(customer);
                TempData["message"] = $"The selected customer was successfully deleted.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
