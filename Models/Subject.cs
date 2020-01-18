using Models.BaseModels;
using Models.JoiningModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Subject:BaseClass
	{
		public string Name { get; set; }
		public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
		public virtual ICollection<Grade> Grades { get; set; }
	}
}
