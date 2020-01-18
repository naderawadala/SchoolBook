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
		public virtual User User { get; set; }
		public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
	}
}
