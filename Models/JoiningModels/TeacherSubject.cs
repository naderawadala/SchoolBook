using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.JoiningModels
{
	public class TeacherSubject
	{
		
		public int TeacherID { get; set; }
		public virtual Teacher Teacher { get; set; }
	
		public int SubjectID { get; set; }
		public virtual Subject Subject { get; set; }
	}
}
