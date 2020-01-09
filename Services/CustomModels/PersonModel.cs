using Services.Common;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.CustomModels
{
	public class PersonModel
	{
		public PersonModel()
		{

		}
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }

		[Password(8, true, true, true, ErrorMessage = "Password must have at least 8 characters, with at least one uppercase, one lowercase" +
			"and one special symbol")]

		[Compare("ConfirmPassword", ErrorMessage = "Passwords do not match!")]
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
	}
}
