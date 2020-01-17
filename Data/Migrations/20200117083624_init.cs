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
                        onDelete: ReferentialAction.Restrict);
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
                    { 1, new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(9937), new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(9967), "Subject1" },
                    { 2, new DateTime(2020, 1, 17, 10, 36, 23, 481, DateTimeKind.Local).AddTicks(1434), new DateTime(2020, 1, 17, 10, 36, 23, 481, DateTimeKind.Local).AddTicks(1463), "Subject2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "DateCreated", "DateModified", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 10, 36, 23, 434, DateTimeKind.Local).AddTicks(6153), new DateTime(2020, 1, 17, 10, 36, 23, 439, DateTimeKind.Local).AddTicks(8763), "Admin@gmail.com", "Admin", "Admin", "AMnHRwYCX1I3KuWctiQLv2HpsZ1Vj9yA1gJngmvNI0A9W02GsQJycUY6fnJOR99FlQ==", "Admin" },
                    { 2, new DateTime(2020, 1, 17, 10, 36, 23, 469, DateTimeKind.Local).AddTicks(9023), new DateTime(2020, 1, 17, 10, 36, 23, 469, DateTimeKind.Local).AddTicks(9101), "Parent@gmail.com", "Parent", "Parent", "ALYgCHthIKBQTZK0LYENw/YPXH5NNHH1tmofpIXgFKf6ZmjfJqOWOrrXeBvqfg4YSQ==", "Parent" },
                    { 3, new DateTime(2020, 1, 17, 10, 36, 23, 472, DateTimeKind.Local).AddTicks(1338), new DateTime(2020, 1, 17, 10, 36, 23, 472, DateTimeKind.Local).AddTicks(1394), "Student@gmail.com", "Student", "Student", "AP3cinWj6ZZNu+/+MBNJ/Qvldymc2ih5k3mLDoltiII5Og3fBqdmkFbgP2k+D+u+Kg==", "Student" },
                    { 4, new DateTime(2020, 1, 17, 10, 36, 23, 473, DateTimeKind.Local).AddTicks(4629), new DateTime(2020, 1, 17, 10, 36, 23, 473, DateTimeKind.Local).AddTicks(4658), "Teacher@gmail.com", "Teacher", "Teacher", "AI9gIeponffvPbbkkf7rkpJ+8eMIQZljBWHTsqC0KpkPKvrBrZCl8Xya/8yQBVxxbw==", "Teacher" },
                    { 5, new DateTime(2020, 1, 17, 10, 36, 23, 474, DateTimeKind.Local).AddTicks(8855), new DateTime(2020, 1, 17, 10, 36, 23, 474, DateTimeKind.Local).AddTicks(8918), "Student2@gmail.com", "Student2", "Student2", "AHb4rvWapfJeOXcgBFRfMNg/X34W+IAF+hnQTnXJ/yidEsGyBN7MMvhPFttCXdmh4g==", "Student" },
                    { 6, new DateTime(2020, 1, 17, 10, 36, 23, 477, DateTimeKind.Local).AddTicks(3488), new DateTime(2020, 1, 17, 10, 36, 23, 477, DateTimeKind.Local).AddTicks(3552), "Teacher2@gmail.com", "Teacher2", "Teacher2", "AGn857s4/ZdasogaPqxuCPq5x6lEb59fBknks/G/H+H5A1xk0NCNHvDZ2oMYGz3YeA==", "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[] { 1, new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(647), new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(708), 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(4014), new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(4050), 3 },
                    { 2, new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(8605), new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(8637), 5 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(6694), new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(6727), 4 },
                    { 2, new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(8775), new DateTime(2020, 1, 17, 10, 36, 23, 480, DateTimeKind.Local).AddTicks(8787), 6 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "ID", "DateCreated", "DateModified", "Score", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 10, 36, 23, 481, DateTimeKind.Local).AddTicks(6284), new DateTime(2020, 1, 17, 10, 36, 23, 481, DateTimeKind.Local).AddTicks(6315), 5.0, 1, 1 },
                    { 2, new DateTime(2020, 1, 17, 10, 36, 23, 482, DateTimeKind.Local).AddTicks(16), new DateTime(2020, 1, 17, 10, 36, 23, 482, DateTimeKind.Local).AddTicks(45), 5.0, 2, 2 }
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
