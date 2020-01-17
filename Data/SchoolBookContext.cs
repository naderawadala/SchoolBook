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
		public DbSet<UserToken> UserTokens { get; set; }

		public DbSet<TeacherSubject> TeacherSubjects { get; set; }
		public DbSet<ParentStudent> ParentStudents { get; set; }
		#endregion

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-R1PO85B\NADERSQL;Database=SchoolBookDB;Trusted_Connection=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Parent>().HasMany(x => x.ParentStudents).WithOne(x => x.Parent).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<Student>().HasMany(x => x.ParentStudents).WithOne(x => x.Student).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<ParentStudent>().HasKey(k => new { k.ParentID, k.StudentID });

			modelBuilder.Entity<Teacher>().HasMany(x => x.TeacherSubjects).WithOne(x => x.Teacher).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<Subject>().HasMany(x => x.TeacherSubjects).WithOne(x => x.Subject).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<TeacherSubject>().HasKey(k => new { k.TeacherID, k.SubjectID });

			#region Seeds

			#region User seeds
			modelBuilder.Entity<User>().HasData(new User
			{
				ID = 1,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				FirstName = "Admin",
				LastName = "Admin",
				Email = "Admin@gmail.com", Password = "Admin123!", Role = "Admin"
			});
			modelBuilder.Entity<User>().HasData(new User
			{
				ID = 2,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				FirstName = "Parent",
				LastName = "Parent",
				Email = "Parent@gmail.com",
				Password = "Parent123!",
				Role = "Parent"
			});
			modelBuilder.Entity<User>().HasData(new User
			{
				ID = 3,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				FirstName = "Student",
				LastName = "Student",
				Email = "Student@gmail.com",
				Password = "Student123!",
				Role = "Student"
			});

			modelBuilder.Entity<User>().HasData(new User
			{
				ID = 4,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				FirstName = "Teacher",
				LastName = "Teacher",
				Email = "Teacher@gmail.com",
				Password = "Teacher123!",
				Role = "Teacher"
			});
			modelBuilder.Entity<User>().HasData(new User
			{
				ID = 5,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				FirstName = "Student2",
				LastName = "Student2",
				Email = "Student2@gmail.com",
				Password = "Student123!",
				Role = "Student"
			});
			modelBuilder.Entity<User>().HasData(new User
			{
				ID = 6,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				FirstName = "Teacher2",
				LastName = "Teacher2",
				Email = "Teacher2@gmail.com",
				Password = "Teacher123!",
				Role = "Teacher"
			});
			#endregion

			modelBuilder.Entity<Parent>().HasData(new Parent
			{
				ID = 1,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserID = 2
			});
			modelBuilder.Entity<Student>().HasData(new Student
			{
				ID = 1,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserID = 3, 
			});
		
			modelBuilder.Entity<Teacher>().HasData(new Teacher
			{
				ID = 1,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserID = 4
			});
			modelBuilder.Entity<Student>().HasData(new Student
			{
				ID = 2,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserID = 5,
			});
			modelBuilder.Entity<Teacher>().HasData(new Teacher
			{
				ID = 2,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				UserID = 6
			});
			modelBuilder.Entity<Subject>().HasData(new Subject
			{
				ID = 1,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				Name = "Subject1"
			});
			modelBuilder.Entity<Subject>().HasData(new Subject
			{
				ID = 2,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				Name = "Subject2"
			});
			modelBuilder.Entity<TeacherSubject>().HasData(new TeacherSubject
			{
				SubjectID = 1,
				TeacherID = 2
			});
			modelBuilder.Entity<TeacherSubject>().HasData(new TeacherSubject
			{
				SubjectID = 2,
				TeacherID = 2
			});
			modelBuilder.Entity<TeacherSubject>().HasData(new TeacherSubject
			{
				SubjectID = 1,
				TeacherID = 1
			});
			modelBuilder.Entity<Grade>().HasData(new Grade
			{
				ID = 1,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now, Score=5, StudentID=1, SubjectID=1, 
			});
			modelBuilder.Entity<Grade>().HasData(new Grade
			{
				ID = 2,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
				Score = 5,
				StudentID = 2,
				SubjectID = 2,
			});
			modelBuilder.Entity<ParentStudent>().HasData(new ParentStudent
			{
				ParentID = 1,
				StudentID = 1
			});
			modelBuilder.Entity<ParentStudent>().HasData(new ParentStudent
			{
				ParentID = 1,
				StudentID = 2
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
