using System;
using System.Collections.Generic;
using System.Text;

namespace Models.JoiningModels
{
	public class ParentStudent
	{
		public int ParentID { get; set; }
		public  Parent Parent { get; set; }

		public int StudentID { get; set; }
		public  Student Student { get; set; }
	}
}
