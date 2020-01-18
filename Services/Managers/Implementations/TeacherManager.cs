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
		private SchoolBookContext dbContext { get; set; }
		public TeacherManager(SchoolBookContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public override bool DeleteByID(int id)
		{
			bool isDeleted = false;
			Teacher item = DbSet.Find(id);
		
			if (item != null)
			{
				User user = dbContext.Users.SingleOrDefault(x => x.ID == item.UserID);
				user.Role = "User";
				dbContext.Update(user);
				dbContext.Teachers.Remove(item);
				isDeleted = true;
				dbContext.SaveChanges();
			}
			return isDeleted;
		}
	}
}
