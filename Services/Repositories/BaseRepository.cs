using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected SchoolBookContext Context;
		protected DbSet<T> DbSet { get { return Context.Set<T>(); } }
		public BaseRepository()
		{
			Context = new SchoolBookContext();
		}
		public void Create(T item)
		{
			DbSet.Add(item);
			Context.SaveChanges();
		}

		public bool DeleteByID(int id)
		{
			bool isDeleted = false;
			T item = DbSet.Find(id);
			if (item != null)
			{
				DbSet.Remove(item);
				isDeleted = true;
			}
			Context.SaveChanges();
			return isDeleted;
		}

		public void Edit(T item, Func<T, bool> findByIDPredicate)
		{
			var find = Context.Set<T>().Local.FirstOrDefault(findByIDPredicate);
			if (find != null)
			{
				Context.Entry(find).State = EntityState.Detached;
			}
			Context.Entry(item).State = EntityState.Modified;
			Context.SaveChanges();
		}

		public List<T> GetAll()
		{
			return DbSet.ToList();
		}

		public T GetByID(int id)
		{
			return DbSet.Find(id);
		}
	}
}
