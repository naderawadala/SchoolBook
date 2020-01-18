using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.JoiningModels;
using Services.CustomModels;
using Services.CustomModels.MapperSettings;
using Services.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Managers.Implementations
{
	public class StudentManager : BaseManager<Student>, IStudentManager
	{
		private SchoolBookContext dbContext { get; set; }
		public StudentManager(SchoolBookContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public List<Grade> GetStudentGrades(int studentID)
		{
			List<Grade> grades = new List<Grade>();
			var query = (dbContext.Grades.Where(x => x.StudentID == studentID));
			foreach (Grade grade in query)
			{
				grades.Add(grade);
			}
			return grades;
		}
		public double GetAverageGrade(int studentID)
		{
			List<Grade> grades = GetStudentGrades(studentID);
			return grades.Average(x => x.Score);
		}

		public override bool DeleteByID(int id)
		{
			bool isDeleted = false;
			Student item = DbSet.Find(id);
			User user = dbContext.Users.SingleOrDefault(x => x.ID == item.UserID);
			if (item != null)
			{
				user.Role = "User";
				dbContext.Update(user);
				DbSet.Remove(item);
				isDeleted = true;
			}
			dbContext.SaveChanges();
			return isDeleted;
		}
	}
}
