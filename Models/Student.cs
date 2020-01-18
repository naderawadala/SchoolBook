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
		public int? UserID { get; set; }
		public virtual User User { get; set; }
		public virtual ICollection<Grade> Grades { get; set; }
		public virtual ICollection<ParentStudent> ParentStudents { get; set; }
	
	}
}
