using Models.BaseModels;
using Models.JoiningModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Teacher:BaseClass
	{
		public int? UserID { get; set; }
		public User User { get; set; }
		public ICollection<TeacherSubject> TeacherSubjects { get; set; }
	}
}
