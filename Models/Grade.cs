using Models.BaseModels;
using Models.JoiningModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
	public class Grade : BaseClass
	{
		[Required]
		[Range(2.0,6.0)]
		public double Score { get; set; }
		public int? StudentID { get; set; }
		public virtual Student Student { get; set; }
		public int? SubjectID { get; set; }
		public virtual Subject Subject { get; set; }
	}
}

