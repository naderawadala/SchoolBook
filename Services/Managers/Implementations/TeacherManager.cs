using Data;
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
	public class TeacherManager:BaseManager<Teacher>, ITeacherManager
	{
		private SchoolBookContext DbContext { get; set; }
		public TeacherManager(SchoolBookContext dbContext)
		{
			this.DbContext = dbContext;
		}
	
	}
}
