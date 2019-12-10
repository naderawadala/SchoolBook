using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
	public interface IBaseRepository<T> where T:class
	{
		void Create(T item);
		T GetByID(int id);
		void Edit(T item, Func<T, bool> findByIDPredicate);
		List<T> GetAll();
		bool DeleteByID(int id);
	}
}
