using SportsPro.Data;
using System;
using System.Collections;
using System.Linq;

namespace SportsPro.BLL
{
    public class CountryManager
    {
        //this method is to return list of Countries key-value
        public static IList GetProductAsKeyValuePairs()
        {
            var context = new SportsProContext();
            var countries = context.Countries.Select(c => new
            {
                Value = c.CountryID,
                Text = c.Name
            }).ToList();
            return countries;
        }
    }
}
