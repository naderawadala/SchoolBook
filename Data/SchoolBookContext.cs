using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Linq;

namespace Data
{
	public class SchoolBookContext:DbContext
	{
		public SchoolBookContext() { }
		public SchoolBookContext(DbContextOptions options):base(options)
		{

		}
		#region Navigation properties
		public DbSet<Grade> Grades { get; set; }
		public DbSet<Parent> Parents { get; set; }
		public DbSet<Student> Students { get; set; }

		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		#endregion

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("@")
		}
	}
}
