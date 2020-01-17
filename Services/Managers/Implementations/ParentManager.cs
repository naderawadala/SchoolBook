using Data;
using Models;
using Services.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Managers.Implementations
{
	public class ParentManager : BaseManager<Parent>, IParentManager
	{
		// let a parent see their child's grades only
		private SchoolBookContext dbContext { get; set; }
		public ParentManager(SchoolBookContext dbContext)
		{
			this.dbContext = dbContext;
		}
		
		public Dictionary<Student,List<Grade>> GetChildGrades(Parent parent)
		{
			Dictionary<Student, List<Grade>> result=new Dictionary<Student, List<Grade>>();
			/*var getParent = dbContext.ParentStudents.FirstOrDefault(x => x.ParentID == parent.ID);
			List<Student> students = new List<Student>();
			students=dbContext.Students.SelectMany(x => x.ID == parent.ID);
			foreach(Student student in students)
			{
				result.Add(student, (List<Grade>)student.Grades);
			}*/
			return result;
		}

	}
}
