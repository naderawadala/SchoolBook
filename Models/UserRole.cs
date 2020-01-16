using Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class UserRole : BaseClass
	{
		public int UserId { get; set; }
		public User User { get; set; }
		public int RoleId { get; set; }
		public Role Role { get; set; }
	}
}
