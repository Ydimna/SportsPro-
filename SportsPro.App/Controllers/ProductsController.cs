using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsPro.App.Models;
using SportsPro.BLL;
using SportsPro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private IHttpContextAccessor http { get; set; }
        private ProductManager data { get; set; }


        // GET: ProductsController
        public ActionResult Index()
        {
            var products = ProductManager.GetAll();
            return View(products);
           
        }

        
        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                //add product by calling method from the product manager
                ProductManager.AddProduct(product);
                TempData["message"] = $"{product.Name} was successfully added.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
                
            }
        }

     

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = ProductManager.Find(id);
            return View(product);
        }

        //POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                //update product by calling method from the product manager
                ProductManager.UpdateProduct(product);
                TempData["message"] = $"{product.Name} was successfully updated.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = ProductManager.Find(id);

            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                //Delete product by calling the delete method from the  product manager
                var ProductName = product.ProductCode;
                ProductManager.DeleteProduct(product);
                TempData["message"] = $"The selected product was successfully deleted.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
