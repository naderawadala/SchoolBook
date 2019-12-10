using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Grade : BaseClass
	{
		public double Score { get; set; }
		public Student Student { get; set; }
		public Subject Subject { get; set; }
	}
}

