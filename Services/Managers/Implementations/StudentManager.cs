using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.CustomModels.MapperSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Managers.Implementations
{
	public class StudentManager:BaseManager<Student>
	{
		// FIND A WAY TO STORE THE AVERAGE STUDENT GRADE
		private SchoolBookContext dbContext { get; set; }
		public StudentManager(SchoolBookContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public List<Student> GetBestStudents(int n)
		{
			var result=
			dbContext.Students.Select(x => new
			{
				StudentName = x.User.FirstName,
				Grade=x.Grades.Average(x=>x.Score)
			}).ToList();
			return null;
		}
		
		public double GetAverageGrade(Student student)
		{
			List<Grade> grades = (List<Grade>)student.Grades;
			return CalculateAverage(grades);
		}
		private double CalculateAverage(List<Grade> grades)
		{
			double sum=0;
			foreach(Grade grade in grades)
			{
				sum += grade.Score;
			}
			return sum / grades.Count;
		}
		// let a student see all his own grades on subjects
	}
}
