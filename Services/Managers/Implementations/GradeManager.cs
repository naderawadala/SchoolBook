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
	public class GradeManager:BaseManager<Grade>, IGradeManager
	{
		private SchoolBookContext dbContext { get; set; }
		public GradeManager(SchoolBookContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public bool SetGrade(SetGradeModel model)
		{
			if(!TeacherMatchesSubject(model.TeacherID, model.SubjectID)){
				return false;
			}
			Grade grade = MapperConfigurator.Mapper.Map<Grade>(model);
			dbContext.Grades.Add(grade);
			dbContext.SaveChanges();
			return true;
		}
		public bool EditGrade(EditGradeModel model)
		{
			var getGrade = dbContext.Grades.SingleOrDefault(x => x.ID == model.ID);
			if (getGrade == null)
			{
				return false;
			}
			getGrade.Score = model.Score;
			dbContext.Update(getGrade);
			dbContext.SaveChanges();
			return true;
		}
		public bool RemoveGrade(RemoveGradeModel model)
		{
			int gradeID = GetGradeID(model.StudentID, model.SubjectID);
			if (gradeID==-1)
			{
				return false;
			}
			Grade grade= dbContext.Grades.Find(gradeID);
			dbContext.Grades.Remove(grade);
			dbContext.SaveChanges();
			return true;
		}
		private int GetGradeID(int studentID, int subjectID)
		{
			var query2 = dbContext.Grades.Include(sub => sub.Subject).Include(t => t.Student);

			foreach (Grade el in query2)
			{
				if (el.StudentID == studentID && el.SubjectID == subjectID)
				{
					return el.ID;
				}
			}
			return -1;
		}
		private bool TeacherMatchesSubject(int teacherID, int subjectID)
		{
			var query2 = dbContext.TeacherSubjects.Include(sub => sub.Subject).Include(t => t.Teacher);

			foreach (TeacherSubject el in query2)
			{
				if (el.TeacherID == teacherID && el.SubjectID == subjectID)
				{
					return true;
				}
			}
			return false;
		}
	}
}
