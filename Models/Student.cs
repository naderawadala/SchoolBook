using Models.BaseModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Student:User
	{
		public ICollection<Grade> Grades { get; set; }
		public ICollection<Parent> Parents { get; set; }
	}
}
