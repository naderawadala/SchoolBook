using Models.BaseModels;
using Models.JoiningModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Student:BaseClass
	{
		public int? UserID;
		public User User { get; set; }
		public ICollection<Grade> Grades { get; set; }
		public ICollection<ParentStudent> ParentStudents { get; set; }
	}
}
