using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Managers.Interfaces
{
	public interface IStudentManager:IBaseManager<Student>
	{
		List<Grade> GetStudentGrades(int studentID);
		double GetAverageGrade(int studentID);
	}
}
