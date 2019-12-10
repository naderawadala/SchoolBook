using Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Parent:User
	{
		public ICollection<Student> Students { get; set; }
	}
}
