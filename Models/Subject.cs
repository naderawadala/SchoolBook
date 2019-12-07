using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Subject:BaseClass
	{
		public string Name { get; set; }
		public List<ICollection> Teacher { get; set; }
	}
}
