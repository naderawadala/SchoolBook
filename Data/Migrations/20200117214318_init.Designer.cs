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
    [Migration("20200117214318_init")]
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
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 599, DateTimeKind.Local).AddTicks(2855),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 599, DateTimeKind.Local).AddTicks(2904),
                            Score = 5.0,
                            StudentID = 1,
                            SubjectID = 1
                        },
                        new
                        {
                            ID = 2,
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 599, DateTimeKind.Local).AddTicks(7018),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 599, DateTimeKind.Local).AddTicks(7059),
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
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 597, DateTimeKind.Local).AddTicks(5075),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 597, DateTimeKind.Local).AddTicks(5148),
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
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 597, DateTimeKind.Local).AddTicks(8697),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 597, DateTimeKind.Local).AddTicks(8769),
                            UserID = 3
                        },
                        new
                        {
                            ID = 2,
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(3509),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(3546),
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
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(4937),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(4971),
                            Name = "Subject1"
                        },
                        new
                        {
                            ID = 2,
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(6664),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(6698),
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
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(1747),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(1794),
                            UserID = 4
                        },
                        new
                        {
                            ID = 2,
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(3687),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(3702),
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
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 565, DateTimeKind.Local).AddTicks(752),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 570, DateTimeKind.Local).AddTicks(5109),
                            Email = "Admin@gmail.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            Password = "ANqMth9WF4REuoUUowdBs2Pnoc9ZK9y9GgIMW63SWhKsyYB9qoQ8ByBi/98GIXi8zg==",
                            Role = "Admin"
                        },
                        new
                        {
                            ID = 2,
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 584, DateTimeKind.Local).AddTicks(5185),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 584, DateTimeKind.Local).AddTicks(5282),
                            Email = "Parent@gmail.com",
                            FirstName = "Parent",
                            LastName = "Parent",
                            Password = "AFvFBV3GCZmwUmAb5mnyJrRKulG021592Jm6dhJdVenh0IU+DqrHg6hX+G0X1L5Daw==",
                            Role = "Parent"
                        },
                        new
                        {
                            ID = 3,
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 587, DateTimeKind.Local).AddTicks(3745),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 587, DateTimeKind.Local).AddTicks(3827),
                            Email = "Student@gmail.com",
                            FirstName = "Student",
                            LastName = "Student",
                            Password = "ACgs/saQL11zLQ4gw+OYfjyETwb6T9jcmSicEg0mqOJc/Fu3djSx+5hQg1BNiHH/NA==",
                            Role = "Student"
                        },
                        new
                        {
                            ID = 4,
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 589, DateTimeKind.Local).AddTicks(9711),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 589, DateTimeKind.Local).AddTicks(9782),
                            Email = "Teacher@gmail.com",
                            FirstName = "Teacher",
                            LastName = "Teacher",
                            Password = "ADrGDm7yKg+EY8vZNTb/AjMYrnRs1GxETL+a7b+YHGhqfPJffttYN7bOzFEYR3cf2g==",
                            Role = "Teacher"
                        },
                        new
                        {
                            ID = 5,
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 592, DateTimeKind.Local).AddTicks(3257),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 592, DateTimeKind.Local).AddTicks(3304),
                            Email = "Student2@gmail.com",
                            FirstName = "Student2",
                            LastName = "Student2",
                            Password = "ADeKWpaYlG3cBMPY/qhJk/LeTpg5fG32f8UQN1vHLWqiPeEUjjbQUen48480MgWuzQ==",
                            Role = "Student"
                        },
                        new
                        {
                            ID = 6,
                            DateCreated = new DateTime(2020, 1, 17, 23, 43, 17, 594, DateTimeKind.Local).AddTicks(7386),
                            DateModified = new DateTime(2020, 1, 17, 23, 43, 17, 594, DateTimeKind.Local).AddTicks(7455),
                            Email = "Teacher2@gmail.com",
                            FirstName = "Teacher2",
                            LastName = "Teacher2",
                            Password = "AAsNIMulwiepfddle6TLGAFLDgsRuI5NqQBpMitTy06OLpRfY7DSNK6c88bwgp4GYQ==",
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