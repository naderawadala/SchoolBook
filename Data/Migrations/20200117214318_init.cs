using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parents_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Score = table.Column<double>(nullable: false),
                    StudentID = table.Column<int>(nullable: true),
                    SubjectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParentStudents",
                columns: table => new
                {
                    ParentID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentStudents", x => new { x.ParentID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_ParentStudents_Parents_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Parents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentStudents_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                columns: table => new
                {
                    TeacherID = table.Column<int>(nullable: false),
                    SubjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => new { x.TeacherID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "ID", "DateCreated", "DateModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(4937), new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(4971), "Subject1" },
                    { 2, new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(6664), new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(6698), "Subject2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "DateCreated", "DateModified", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 23, 43, 17, 565, DateTimeKind.Local).AddTicks(752), new DateTime(2020, 1, 17, 23, 43, 17, 570, DateTimeKind.Local).AddTicks(5109), "Admin@gmail.com", "Admin", "Admin", "ANqMth9WF4REuoUUowdBs2Pnoc9ZK9y9GgIMW63SWhKsyYB9qoQ8ByBi/98GIXi8zg==", "Admin" },
                    { 2, new DateTime(2020, 1, 17, 23, 43, 17, 584, DateTimeKind.Local).AddTicks(5185), new DateTime(2020, 1, 17, 23, 43, 17, 584, DateTimeKind.Local).AddTicks(5282), "Parent@gmail.com", "Parent", "Parent", "AFvFBV3GCZmwUmAb5mnyJrRKulG021592Jm6dhJdVenh0IU+DqrHg6hX+G0X1L5Daw==", "Parent" },
                    { 3, new DateTime(2020, 1, 17, 23, 43, 17, 587, DateTimeKind.Local).AddTicks(3745), new DateTime(2020, 1, 17, 23, 43, 17, 587, DateTimeKind.Local).AddTicks(3827), "Student@gmail.com", "Student", "Student", "ACgs/saQL11zLQ4gw+OYfjyETwb6T9jcmSicEg0mqOJc/Fu3djSx+5hQg1BNiHH/NA==", "Student" },
                    { 4, new DateTime(2020, 1, 17, 23, 43, 17, 589, DateTimeKind.Local).AddTicks(9711), new DateTime(2020, 1, 17, 23, 43, 17, 589, DateTimeKind.Local).AddTicks(9782), "Teacher@gmail.com", "Teacher", "Teacher", "ADrGDm7yKg+EY8vZNTb/AjMYrnRs1GxETL+a7b+YHGhqfPJffttYN7bOzFEYR3cf2g==", "Teacher" },
                    { 5, new DateTime(2020, 1, 17, 23, 43, 17, 592, DateTimeKind.Local).AddTicks(3257), new DateTime(2020, 1, 17, 23, 43, 17, 592, DateTimeKind.Local).AddTicks(3304), "Student2@gmail.com", "Student2", "Student2", "ADeKWpaYlG3cBMPY/qhJk/LeTpg5fG32f8UQN1vHLWqiPeEUjjbQUen48480MgWuzQ==", "Student" },
                    { 6, new DateTime(2020, 1, 17, 23, 43, 17, 594, DateTimeKind.Local).AddTicks(7386), new DateTime(2020, 1, 17, 23, 43, 17, 594, DateTimeKind.Local).AddTicks(7455), "Teacher2@gmail.com", "Teacher2", "Teacher2", "AAsNIMulwiepfddle6TLGAFLDgsRuI5NqQBpMitTy06OLpRfY7DSNK6c88bwgp4GYQ==", "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[] { 1, new DateTime(2020, 1, 17, 23, 43, 17, 597, DateTimeKind.Local).AddTicks(5075), new DateTime(2020, 1, 17, 23, 43, 17, 597, DateTimeKind.Local).AddTicks(5148), 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 23, 43, 17, 597, DateTimeKind.Local).AddTicks(8697), new DateTime(2020, 1, 17, 23, 43, 17, 597, DateTimeKind.Local).AddTicks(8769), 3 },
                    { 2, new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(3509), new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(3546), 5 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(1747), new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(1794), 4 },
                    { 2, new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(3687), new DateTime(2020, 1, 17, 23, 43, 17, 598, DateTimeKind.Local).AddTicks(3702), 6 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "ID", "DateCreated", "DateModified", "Score", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 23, 43, 17, 599, DateTimeKind.Local).AddTicks(2855), new DateTime(2020, 1, 17, 23, 43, 17, 599, DateTimeKind.Local).AddTicks(2904), 5.0, 1, 1 },
                    { 2, new DateTime(2020, 1, 17, 23, 43, 17, 599, DateTimeKind.Local).AddTicks(7018), new DateTime(2020, 1, 17, 23, 43, 17, 599, DateTimeKind.Local).AddTicks(7059), 5.0, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ParentStudents",
                columns: new[] { "ParentID", "StudentID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TeacherSubjects",
                columns: new[] { "TeacherID", "SubjectID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentID",
                table: "Grades",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectID",
                table: "Grades",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_UserID",
                table: "Parents",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ParentStudents_StudentID",
                table: "ParentStudents",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserID",
                table: "Students",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserID",
                table: "Teachers",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SubjectID",
                table: "TeacherSubjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "ParentStudents");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
