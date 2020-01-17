using Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
	public class User : BaseClass
	{
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
		public virtual Parent Parent { get; set; }
		public virtual Student Student { get; set; }
		public virtual Teacher Teacher { get; set; }
		public virtual ICollection<UserToken> UserTokens { get; set; }
		public string? Role { get; set; }
	}
}
