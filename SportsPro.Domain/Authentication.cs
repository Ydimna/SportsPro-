using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportsPro.Domain
{
	[Table("Authentication")]
	public class Authentication
	{
		public int AuthenticationID { get; set; }

		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }

	}
}
