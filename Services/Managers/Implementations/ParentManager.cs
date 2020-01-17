using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.JoiningModels;
using Services.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Managers.Implementations
{
	public class ParentManager : BaseManager<Parent>, IParentManager
	{
		private SchoolBookContext dbContext { get; set; }
		public ParentManager(SchoolBookContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public List<Grade> GetChildGrades(int parentID)
		{
			List<int> students = GetStudentIDs(parentID);
			List<Grade> grades = new List<Grade>();
		
			if (students.Count == 0)
			{
				return null;
			}
			foreach(int student in students)
			{
				var query = (dbContext.Grades.Where(x => x.StudentID == student));
				foreach(Grade grade in query)
				{
					grades.Add(grade);
				}
			}
			return grades;
			
		}
		private List<int> GetStudentIDs(int parentID)
		{
			var query = dbContext.ParentStudents.Include(x => x.Parent).Include(x => x.Student);
			List<int> students = new List<int>();
			foreach (ParentStudent el in query)
			{
				if (el.ParentID == parentID)
				{
					students.Add(el.Student.ID);
				}
			}
			return students;
		}
	}
}
