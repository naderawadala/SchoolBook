using Models.BaseModels;
using Models.JoiningModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Teacher:User
	{
		public ICollection<TeacherSubject> TeacherSubjects { get; set; }
	}
}
