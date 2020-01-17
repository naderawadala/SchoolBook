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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(7835), new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(7854), "Subject1" },
                    { 2, new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(8709), new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(8728), "Subject2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "DateCreated", "DateModified", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 23, 34, 35, 411, DateTimeKind.Local).AddTicks(5775), new DateTime(2020, 1, 17, 23, 34, 35, 414, DateTimeKind.Local).AddTicks(7924), "Admin@gmail.com", "Admin", "Admin", "AGjAOuKvnzJuYEeRQUIryVPnEexaemytkIm9hwNJuZdsPIzHTFqNfelxmRiCqB0chg==", "Admin" },
                    { 2, new DateTime(2020, 1, 17, 23, 34, 35, 422, DateTimeKind.Local).AddTicks(2622), new DateTime(2020, 1, 17, 23, 34, 35, 422, DateTimeKind.Local).AddTicks(2689), "Parent@gmail.com", "Parent", "Parent", "AAzDep7mVeSMnZ2x2uAgSuGQ02J9Y3aBehkMs+Ggkfr6cMgXUW2sE5xQATNamA8MAQ==", "Parent" },
                    { 3, new DateTime(2020, 1, 17, 23, 34, 35, 423, DateTimeKind.Local).AddTicks(5409), new DateTime(2020, 1, 17, 23, 34, 35, 423, DateTimeKind.Local).AddTicks(5428), "Student@gmail.com", "Student", "Student", "AEGcEjJdZSqJ2xK3bTKAmsf1iEo8s27+hblcJiE76JwXbiHMReitSWy8UNFw/mRAzA==", "Student" },
                    { 4, new DateTime(2020, 1, 17, 23, 34, 35, 424, DateTimeKind.Local).AddTicks(6646), new DateTime(2020, 1, 17, 23, 34, 35, 424, DateTimeKind.Local).AddTicks(6654), "Teacher@gmail.com", "Teacher", "Teacher", "AHuAzm8XOlKPfer7BVUi4vc+fVnTa5fQR9pY79+xQ2T7xok8m2FUYAiQC8RXd96WVg==", "Teacher" },
                    { 5, new DateTime(2020, 1, 17, 23, 34, 35, 425, DateTimeKind.Local).AddTicks(8338), new DateTime(2020, 1, 17, 23, 34, 35, 425, DateTimeKind.Local).AddTicks(8357), "Student2@gmail.com", "Student2", "Student2", "AGs0njTg6V0GHnaT1mnzRqyA8sPXCHbbgi1rNz03uJ4/ZhD/RjmyLFfXoicB1I+UcA==", "Student" },
                    { 6, new DateTime(2020, 1, 17, 23, 34, 35, 426, DateTimeKind.Local).AddTicks(9576), new DateTime(2020, 1, 17, 23, 34, 35, 426, DateTimeKind.Local).AddTicks(9584), "Teacher2@gmail.com", "Teacher2", "Teacher2", "ABRw2XNXpsfn9al7CUoKTmoMILTvoEehzkiqRaX9OOdkUHCfeL1Uzq2ybcOBYWIArQ==", "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[] { 1, new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(2848), new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(2871), 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(4595), new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(4616), 3 },
                    { 2, new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(7072), new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(7092), 5 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(6153), new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(6174), 4 },
                    { 2, new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(7159), new DateTime(2020, 1, 17, 23, 34, 35, 428, DateTimeKind.Local).AddTicks(7165), 6 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "ID", "DateCreated", "DateModified", "Score", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 23, 34, 35, 429, DateTimeKind.Local).AddTicks(1600), new DateTime(2020, 1, 17, 23, 34, 35, 429, DateTimeKind.Local).AddTicks(1622), 5.0, 1, 1 },
                    { 2, new DateTime(2020, 1, 17, 23, 34, 35, 429, DateTimeKind.Local).AddTicks(4073), new DateTime(2020, 1, 17, 23, 34, 35, 429, DateTimeKind.Local).AddTicks(4094), 5.0, 2, 2 }
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
