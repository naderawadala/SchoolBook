﻿using Models.BaseModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Teacher:User
	{
		public ICollection<Subject> Subjects { get; set; }
	}
}
