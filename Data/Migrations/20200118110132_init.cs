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
                    { 1, new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(7606), new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(7628), "Subject1" },
                    { 2, new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(8597), new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(8618), "Subject2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "DateCreated", "DateModified", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 18, 13, 1, 31, 519, DateTimeKind.Local).AddTicks(8720), new DateTime(2020, 1, 18, 13, 1, 31, 524, DateTimeKind.Local).AddTicks(4410), "Admin@gmail.com", "Admin", "Admin", "AG/Y8oifFGs/dD0EyUZPc3osP1GufT29XwKW9AuO1w6UGDj7w6vMGpxds5/Cz6/8KQ==", "Admin" },
                    { 2, new DateTime(2020, 1, 18, 13, 1, 31, 533, DateTimeKind.Local).AddTicks(4627), new DateTime(2020, 1, 18, 13, 1, 31, 533, DateTimeKind.Local).AddTicks(4705), "Parent@gmail.com", "Parent", "Parent", "ADdKM7DMUJWXWdT/vM1wX420NQ1uNsWxXWlrO9AlKsp6WvUShUj+K2+7t6LRxd6XDQ==", "Parent" },
                    { 3, new DateTime(2020, 1, 18, 13, 1, 31, 534, DateTimeKind.Local).AddTicks(8070), new DateTime(2020, 1, 18, 13, 1, 31, 534, DateTimeKind.Local).AddTicks(8091), "Student@gmail.com", "Student", "Student", "AGy3BM8BnvEdQDd/6dYg9J8M63CRUnmZP5HPz+TdikraYrMthlPgE8kLp+ihhWuVNA==", "Student" },
                    { 4, new DateTime(2020, 1, 18, 13, 1, 31, 536, DateTimeKind.Local).AddTicks(695), new DateTime(2020, 1, 18, 13, 1, 31, 536, DateTimeKind.Local).AddTicks(708), "Teacher@gmail.com", "Teacher", "Teacher", "AAT+EaIBJwPrMs3vSxM74/G2yVbTrpXV9XZpG63kSRtga6v1sMDayR6E4mw/fCFqaw==", "Teacher" },
                    { 5, new DateTime(2020, 1, 18, 13, 1, 31, 537, DateTimeKind.Local).AddTicks(5438), new DateTime(2020, 1, 18, 13, 1, 31, 537, DateTimeKind.Local).AddTicks(5470), "Student2@gmail.com", "Student2", "Student2", "AGeh9B5ZOLLw8tw9XFxC7XD0nYTxKzV0bGlkI656DyPpXQq8+TUeIr87j3nzuuU1bA==", "Student" },
                    { 6, new DateTime(2020, 1, 18, 13, 1, 31, 538, DateTimeKind.Local).AddTicks(7908), new DateTime(2020, 1, 18, 13, 1, 31, 538, DateTimeKind.Local).AddTicks(7918), "Teacher2@gmail.com", "Teacher2", "Teacher2", "AKqkDLmB6dEloFHgu99INXs2oXesQTHynGmAXwhjyaJj8ss39A/uYRCrJo8+ACaGMQ==", "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[] { 1, new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(1771), new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(1800), 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(3917), new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(3942), 3 },
                    { 2, new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(6731), new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(6755), 5 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(5682), new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(5707), 4 },
                    { 2, new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(6833), new DateTime(2020, 1, 18, 13, 1, 31, 540, DateTimeKind.Local).AddTicks(6840), 6 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "ID", "DateCreated", "DateModified", "Score", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 18, 13, 1, 31, 541, DateTimeKind.Local).AddTicks(2237), new DateTime(2020, 1, 18, 13, 1, 31, 541, DateTimeKind.Local).AddTicks(2263), 5.0, 1, 1 },
                    { 2, new DateTime(2020, 1, 18, 13, 1, 31, 541, DateTimeKind.Local).AddTicks(4830), new DateTime(2020, 1, 18, 13, 1, 31, 541, DateTimeKind.Local).AddTicks(4855), 5.0, 2, 2 }
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
