using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Domain
{
    [Table("Country")]
    public class Country
    {
        [Required]
        public string CountryID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
