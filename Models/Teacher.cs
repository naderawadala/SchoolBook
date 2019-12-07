using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Teacher:BaseClass
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public List<ICollection> Subject { get; set; }
	}
}
