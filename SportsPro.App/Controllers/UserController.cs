using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsPro.BLL;
using SportsPro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SportsPro.App.Controllers
{
    public class UserController : Controller
    {
        private IHttpContextAccessor http { get; set; }

        // Route: /UserController/Login
        public ActionResult Login(string returnUrl = null)// this method responds to Get
        {
            if (returnUrl != null)
                TempData["ReturnUrl"] = returnUrl;//get the latest page(URL) the user visit to return to it when he login
            return View();
        }

        //Login Asynch method that will handle the Post 
        [HttpPost]
        public async Task<IActionResult> LoginAsync(Authentication user)
        {
            //authentication using the manager
            var usr = UserManager.Authenticate(user.Username, user.Password);
            if (user == null)
            {
                return View();
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usr.Username),
                new Claim(ClaimTypes.Role, usr.Username)
                //Add new claim if you add more properties to the database
                //like other column "First name" ... "LastName"...."Role"
            };

            var claimsIdentity = new ClaimsIdentity(claims,"Cookies");

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            if (TempData["ReturnUrl"] == null)// sent you back to the home page
                return RedirectToAction("Index", "Home");
            else
                return Redirect(TempData["ReturnUrl"].ToString());
        }
        
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Denied()
        {
            return View();
        }
        ////////////////////////////////////////////////////////////
        
    }
}
