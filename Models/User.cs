using Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
	public class User : BaseClass
	{
		public User()
		{
			UserTokens = new HashSet<UserToken>();
			UserRoles = new HashSet<UserRoles>();
		}
		[Required]
		[StringLength(maximumLength: 50, MinimumLength = 5)]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		[Required(ErrorMessage = "First name is required!")]
		[MaxLength(20)]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Last name is required!")]
		[MaxLength(20)]
		public string LastName { get; set; }

		public Parent Parent { get; set; }
		public Student Student { get; set; }
		public Teacher Teacher { get; set; }
		public virtual ICollection<UserToken> UserTokens { get; set; }
		public virtual ICollection<UserRoles> UserRoles { get; set; }
	}
}
