using Models.BaseModels;
using Models.JoiningModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Parent:User
	{
		public ICollection<ParentStudent> ParentStudents { get; set; }
	}
}
