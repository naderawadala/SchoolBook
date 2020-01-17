using System;
using System.Collections.Generic;
using System.Text;

namespace Services.CustomModels
{
	public class SetGradeModel
	{
		public int TeacherID { get; set; }
		public double Score { get; set; }
		public int StudentID { get; set; }
		public int SubjectID { get; set; }
	}
}
