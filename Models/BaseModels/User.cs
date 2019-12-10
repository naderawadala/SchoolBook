using System;
using System.Collections.Generic;
using System.Text;

namespace Models.BaseModels
{
	public class User:BaseClass
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string HashedPassword { get; set; }
	}
}
