using SportsPro.Data;
using SportsPro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsPro.BLL
{
    public class AuthenticationManager
    {
        //This method return list of Authentications
        public static IList<Authentication> GetAll()
        {
            var context = new SportsProContext();
            var auth = context.Authentications.ToList();
            return auth;
        }

        //This method to add Authentication
        public static void Add(Authentication authentication)
        {
            var context = new SportsProContext();
            context.Authentications.Add(authentication);
            context.SaveChanges();
        }

        //This method to find Authentication
        public static Authentication Find(int id)
        {
            var context = new SportsProContext();
            var authentication = context.Authentications.Find(id);
            return authentication;
        }

        //This method to delete Authentication
        public static void Delete(Authentication authentication)
        {
            var context = new SportsProContext();
            context.Authentications.Remove(authentication);
            context.SaveChanges();
        }

        //This method to Update Authentication
        public static void Update(Authentication authentication)
        {
            var context = new SportsProContext();
            var originalAuth = context.Authentications.Find(authentication.AuthenticationID);
            originalAuth.Username = authentication.Username;
            originalAuth.Password = authentication.Password;
            context.SaveChanges();
        }
    }
}
