using Models.BaseModels;
using Models.JoiningModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Parent:BaseClass
	{
		public int? UserID;
		public User User { get; set; }
		public ICollection<ParentStudent> ParentStudents { get; set; }
	}
}
