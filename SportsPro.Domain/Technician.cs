using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportsPro.Domain
{
	[Table("Technician")]
	public class Technician
    {
		public int TechnicianID { get; set; }

		[Required]
		public string Name { get; set; }

		[Required(ErrorMessage = "Email Required.")]
		[StringLength(51, ErrorMessage = "Must be 51 characters or less")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[RegularExpression(@"^\(([0-9]{3})\)[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number must be in (999) 999-9999 format.")]
		public string Phone { get; set; }
	}
}
