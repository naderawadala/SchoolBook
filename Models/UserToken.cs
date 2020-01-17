using Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class UserToken : BaseClass
	{
		public string Token { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
	}
}
