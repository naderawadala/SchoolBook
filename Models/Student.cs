﻿using Models.BaseModels;
using Models.JoiningModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Student:BaseClass
	{
		public int? UserID { get; set; }
		public User User { get; set; }
		public ICollection<Grade> Grades { get; set; }
		public ICollection<ParentStudent> ParentStudents { get; set; }
		/* 
		 * WIP STUDENT GRADE
		 * public double AvgGrade { get; set; }
		private double CalcAvgGrade()
		{
			double avg = 0;
			foreach (Grade grade in Grades)
			{
				avg += grade.Score;
			}
			return avg / Grades.Count;
		}
		*/
	}
}
