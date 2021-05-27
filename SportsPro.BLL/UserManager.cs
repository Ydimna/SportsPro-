using SportsPro.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using SportsPro.Data;
using System.Linq;

namespace SportsPro.BLL
{
    /// <summary>
    /// CLass is responsible for authentication and managing users
    /// </summary>
    public class UserManager
    {
        /// <summary>
        /// User is authenticated based on credentials and a user returned if exists or null if not.
        /// </summary>
        /// <param name="username">User name as string</param>
        /// <param name="password">Password as string</param>
        /// <returns>A user object or null</returns>
        public static Authentication Authenticate(string username, string password)
        {
            var context = new SportsProContext();
            var user = context.Authentications.SingleOrDefault
                (usr => usr.Username == username && usr.Password == password);
            return user;
        }
    }
}
