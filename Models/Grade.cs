using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Grade : BaseClass
	{
		public double Score { get; set; }
		public ICollection<Student> Students { get; set; }
		public ICollection<Subject> Subjects { get; set; }
	}
}

