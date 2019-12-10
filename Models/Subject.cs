using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Subject:BaseClass
	{
		public string Name { get; set; }
		public ICollection<Teacher> Teachers { get; set; }
		public ICollection<Grade> Grades { get; set; }
	}
}
