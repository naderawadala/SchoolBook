using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Managers.Implementations
{
	public class ParentManager:BaseManager<Parent>
	{
		// let a parent see their child's grades only
		private SchoolBookContext dbContext { get; set; }
		public ParentManager(SchoolBookContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public List<Grade> GetChildGrades(Parent parent)
		{
			Student student = (Student)dbContext.ParentStudents.Where(x => x.ParentID == parent.ID).Select(x => x.Student);
			return student.Grades.ToList();
		}
	}
}
