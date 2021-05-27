using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportsPro.Domain
{
	[Table("Registration")]
	public class Registration
	{

		public int RegistrationID { get; set; }

		[Required]
		public int CustomerID { get; set; }     // foreign key property
		public Customer Customer { get; set; }  // navigation property

		[Required]
		public int ProductID { get; set; }     // foreign key property
		public Product Product { get; set; }   // navigation property
		
	}
}
