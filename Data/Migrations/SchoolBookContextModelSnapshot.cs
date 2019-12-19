﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(SchoolBookContext))]
    partial class SchoolBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
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
                });

            modelBuilder.Entity("Models.JoiningModels.ParentStudent", b =>
                {
                    b.Property<int>("ParentID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ParentID", "StudentID");

                    b.HasIndex("StudentID");

                    b.ToTable("ParentStudent");
                });

            modelBuilder.Entity("Models.JoiningModels.TeacherSubject", b =>
                {
                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.HasKey("TeacherID", "SubjectID");

                    b.HasIndex("SubjectID");

                    b.ToTable("TeacherSubject");
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

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateCreated = new DateTime(2019, 12, 19, 19, 43, 17, 951, DateTimeKind.Local).AddTicks(1607),
                            DateModified = new DateTime(2019, 12, 19, 19, 43, 17, 954, DateTimeKind.Local).AddTicks(5238),
                            HashedPassword = "fadrea",
                            Username = "John"
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

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Students");
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

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Models.Grade", b =>
                {
                    b.HasOne("Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentID");

                    b.HasOne("Models.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectID");
                });

            modelBuilder.Entity("Models.JoiningModels.ParentStudent", b =>
                {
                    b.HasOne("Models.Parent", "Parent")
                        .WithMany("ParentStudents")
                        .HasForeignKey("ParentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Models.Student", "Student")
                        .WithMany("ParentStudents")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.JoiningModels.TeacherSubject", b =>
                {
                    b.HasOne("Models.Subject", "Subject")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Models.Teacher", "Teacher")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
