using Microsoft.EntityFrameworkCore;
using Models;
using Models.BaseModels;
using Models.JoiningModels;
using System;
using System.Linq;

namespace Data
{
	public class SchoolBookContext : DbContext
	{
		public SchoolBookContext() { }
		public SchoolBookContext(DbContextOptions options) : base(options)
		{

		}
		#region Navigation properties
		public DbSet<Grade> Grades { get; set; }
		public DbSet<Parent> Parents { get; set; }
		public DbSet<Student> Students { get; set; }

		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserRoles> UserRoles { get; set; }
		public DbSet<UserToken> UserTokens { get; set; }
		#endregion

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-R1PO85B\NADERSQL;Database=SchoolBookDB;Trusted_Connection=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Parent>().HasMany(x => x.ParentStudents).WithOne(x => x.Parent).OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Student>().HasMany(x => x.ParentStudents).WithOne(x => x.Student).OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<ParentStudent>().HasKey(k => new { k.ParentID, k.StudentID });

			modelBuilder.Entity<Teacher>().HasMany(x => x.TeacherSubjects).WithOne(x => x.Teacher).OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Subject>().HasMany(x => x.TeacherSubjects).WithOne(x => x.Subject).OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<TeacherSubject>().HasKey(k => new { k.TeacherID, k.SubjectID });

			#region Seeds
			modelBuilder.Entity<Parent>().HasData(new Parent
			{
				ID = 1,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				User=new User { FirstName="John", LastName="Boyega",Email="johnboyega@gmail.com"}

			});
				
			
			#endregion
		}

		public override int SaveChanges()
		{
			SetTimestamps();
			return base.SaveChanges();
		}
		private void SetTimestamps()
		{
			var entries = ChangeTracker
				.Entries()
				.Where(e => e.Entity is BaseClass && (e.State == EntityState.Added) || (e.State == EntityState.Modified));
			foreach (var entry in entries)
			{
				((BaseClass)entry.Entity).DateModified = DateTime.Now;
				if (entry.State == EntityState.Added)
				{
					((BaseClass)entry.Entity).DateCreated = DateTime.Now;
				}
			}
		}
	}
}
