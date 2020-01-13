using Models.BaseModels;
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
		[Required]
		public Student Student { get; set; }
		[Required]
		public Subject Subject { get; set; }
	}
}

