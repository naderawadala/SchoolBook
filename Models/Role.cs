using System;
using System.Collections.Generic;
using System.Text;
using Models.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{

	[Table("Roles")]
	public class Role : BaseClass
	{
		[Required]
		[MinLength(2)]
		[MaxLength(10)]
		public string RoleName { get; set; }
		public virtual ICollection<UserRoles> UserRoles { get; set; }
	}
}
