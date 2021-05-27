using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportsPro.Domain
{
	[Table("Product")]
	public class Product
    {
		public int ProductID { get; set; }

		[Required]
		[Display(Name = "Code")]
		public string ProductCode { get; set; }

		[Required]
		public string Name { get; set; }

		[Range(0, 1000000)]
		[Column(TypeName = "decimal(8,2)")]
		[Display(Name = "Price")]
		public decimal YearlyPrice { get; set; }
		[Display(Name = "Release Date")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime ReleaseDate { get; set; } = DateTime.Now;

		public ICollection<Registration> Registrations { get; set; }
	}
}
