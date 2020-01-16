using Models;
using Newtonsoft.Json;
using Services.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.CustomModels
{
	public class RegisterModel
	{
		[Required]
		[JsonProperty("email")]
		public string Email { get; set; }


		[Required]
		[JsonProperty("password")]

		[Password(8, true, true, true, ErrorMessage = "Password must have at least 8 characters, with at least one uppercase, one lowercase" +
			"and one special symbol")]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "Passwords do not match!")]
		
		public string ConfirmPassword { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }

	}
}
