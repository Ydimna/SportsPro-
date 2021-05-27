using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportsPro.Domain
{
	[Table("Incident")]
	public class Incident
    {
		
		public int IncidentID { get; set; }

		[Required]
		public int CustomerID { get; set; }     // foreign key property
		public Customer Customer { get; set; }  // navigation property

		[Required]
		public int ProductID { get; set; }     // foreign key property
		public Product Product { get; set; }   // navigation property

		public int? TechnicianID { get; set; }     // foreign key property - nullable
		public Technician Technician { get; set; }   // navigation property

		[Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		[Display(Name = "Date Opened")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime DateOpened { get; set; } = DateTime.Now;

		[Display(Name = "Date Closed")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? DateClosed { get; set; } = null;
	}
}
