using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
	public class SchoolBookContext:DbContext
	{
		public SchoolBookContext(DbContextOptions options):base(options)
		{

		}


	}
}
