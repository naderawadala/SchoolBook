using Data;
using Microsoft.EntityFrameworkCore;
using Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
	public class UserRepository
	{
		private SchoolBookContext Context;
		private DbSet<User> DbSet { get { return Context.Set<User>(); } }
		public UserRepository()
		{
			Context = new SchoolBookContext();
		}
	}
}
