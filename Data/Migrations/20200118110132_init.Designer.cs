﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(SchoolBookContext))]
    [Migration("20200118110132_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Grade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StudentID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 541, DateTimeKind.Local).AddTicks(2237),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 541, DateTimeKind.Local).AddTicks(2263),
                            Score = 5.0,
                            StudentID = 1,
                            SubjectID = 1
                        },
                        new
                        {
                            ID = 2,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 541, DateTimeKind.Local).AddTicks(4830),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 541, DateTimeKind.Local).AddTicks(4855),
                            Score = 5.0,
                            StudentID = 2,
                            SubjectID = 2
                        });
                });

            modelBuilder.Entity("Models.JoiningModels.ParentStudent", b =>
                {
                    b.Property<int>("ParentID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ParentID", "StudentID");

                    b.HasIndex("StudentID");

                    b.ToTable("ParentStudents");

                    b.HasData(
                        new
                        {
                            ParentID = 1,
                            StudentID = 1
                        },
                        new
                        {
                            ParentID = 1,
                            StudentID = 2
                        });
                });

            modelBuilder.Entity("Models.JoiningModels.TeacherSubject", b =>
                {
                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("TeacherID", "SubjectID");

                    b.HasIndex("SubjectID");

                    b.ToTable("TeacherSubjects");

                    b.HasData(
                        new
                        {
                            TeacherID = 2,
                            SubjectID = 1
                        },
                        new
                        {
                            TeacherID = 2,
                            SubjectID = 2
                        },
                        new
                        {
                            TeacherID = 1,
                            SubjectID = 1
                        });
                });

            modelBuilder.Entity("Models.Parent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(1771),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(1800),
                            UserID = 2
                        });
                });

            modelBuilder.Entity("Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(3917),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(3942),
                            UserID = 3
                        },
                        new
                        {
                            ID = 2,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(6731),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(6755),
                            UserID = 5
                        });
                });

            modelBuilder.Entity("Models.Subject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(7606),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(7628),
                            Name = "Subject1"
                        },
                        new
                        {
                            ID = 2,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(8597),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(8618),
                            Name = "Subject2"
                        });
                });

            modelBuilder.Entity("Models.Teacher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(5682),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(5707),
                            UserID = 4
                        },
                        new
                        {
                            ID = 2,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(6833),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(6840),
                            UserID = 6
                        });
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 519, DateTimeKind.Local).AddTicks(8720),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 524, DateTimeKind.Local).AddTicks(4410),
                            Email = "Admin@gmail.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            Password = "AG/Y8oifFGs/dD0EyUZPc3osP1GufT29XwKW9AuO1w6UGDj7w6vMGpxds5/Cz6/8KQ==",
                            Role = "Admin"
                        },
                        new
                        {
                            ID = 2,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 533, DateTimeKind.Local).AddTicks(4627),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 533, DateTimeKind.Local).AddTicks(4705),
                            Email = "Parent@gmail.com",
                            FirstName = "Parent",
                            LastName = "Parent",
                            Password = "ADdKM7DMUJWXWdT/vM1wX420NQ1uNsWxXWlrO9AlKsp6WvUShUj+K2+7t6LRxd6XDQ==",
                            Role = "Parent"
                        },
                        new
                        {
                            ID = 3,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 534, DateTimeKind.Local).AddTicks(8070),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 534, DateTimeKind.Local).AddTicks(8091),
                            Email = "Student@gmail.com",
                            FirstName = "Student",
                            LastName = "Student",
                            Password = "AGy3BM8BnvEdQDd/6dYg9J8M63CRUnmZP5HPz+TdikraYrMthlPgE8kLp+ihhWuVNA==",
                            Role = "Student"
                        },
                        new
                        {
                            ID = 4,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 536, DateTimeKind.Local).AddTicks(695),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 536, DateTimeKind.Local).AddTicks(708),
                            Email = "Teacher@gmail.com",
                            FirstName = "Teacher",
                            LastName = "Teacher",
                            Password = "AAT+EaIBJwPrMs3vSxM74/G2yVbTrpXV9XZpG63kSRtga6v1sMDayR6E4mw/fCFqaw==",
                            Role = "Teacher"
                        },
                        new
                        {
                            ID = 5,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 537, DateTimeKind.Local).AddTicks(5438),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 537, DateTimeKind.Local).AddTicks(5470),
                            Email = "Student2@gmail.com",
                            FirstName = "Student2",
                            LastName = "Student2",
                            Password = "AGeh9B5ZOLLw8tw9XFxC7XD0nYTxKzV0bGlkI656DyPpXQq8+TUeIr87j3nzuuU1bA==",
                            Role = "Student"
                        },
                        new
                        {
                            ID = 6,
                            DateCreated = new DateTime(2020, 1, 18, 13, 1, 31, 538, DateTimeKind.Local).AddTicks(7908),
                            DateModified = new DateTime(2020, 1, 18, 13, 1, 31, 538, DateTimeKind.Local).AddTicks(7918),
                            Email = "Teacher2@gmail.com",
                            FirstName = "Teacher2",
                            LastName = "Teacher2",
                            Password = "AKqkDLmB6dEloFHgu99INXs2oXesQTHynGmAXwhjyaJj8ss39A/uYRCrJo8+ACaGMQ==",
                            Role = "Teacher"
                        });
                });

            modelBuilder.Entity("Models.UserToken", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Models.Grade", b =>
                {
                    b.HasOne("Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectID");
                });

            modelBuilder.Entity("Models.JoiningModels.ParentStudent", b =>
                {
                    b.HasOne("Models.Parent", "Parent")
                        .WithMany("ParentStudents")
                        .HasForeignKey("ParentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Student", "Student")
                        .WithMany("ParentStudents")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.JoiningModels.TeacherSubject", b =>
                {
                    b.HasOne("Models.Subject", "Subject")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Teacher", "Teacher")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Parent", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithOne("Parent")
                        .HasForeignKey("Models.Parent", "UserID");
                });

            modelBuilder.Entity("Models.Student", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("Models.Student", "UserID");
                });

            modelBuilder.Entity("Models.Teacher", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithOne("Teacher")
                        .HasForeignKey("Models.Teacher", "UserID");
                });

            modelBuilder.Entity("Models.UserToken", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}