using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class seedaddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_SubjectID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudents_Parents_ParentID",
                table: "ParentStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudents_Students_StudentID",
                table: "ParentStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectID",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherID",
                table: "TeacherSubjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserTokens");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectID",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "ID", "DateCreated", "DateModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 9, 47, 33, 865, DateTimeKind.Local).AddTicks(1310), new DateTime(2020, 1, 17, 9, 47, 33, 865, DateTimeKind.Local).AddTicks(1340), "Subject1" },
                    { 2, new DateTime(2020, 1, 17, 9, 47, 33, 865, DateTimeKind.Local).AddTicks(2798), new DateTime(2020, 1, 17, 9, 47, 33, 865, DateTimeKind.Local).AddTicks(2828), "Subject2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "DateCreated", "DateModified", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 9, 47, 33, 855, DateTimeKind.Local).AddTicks(4437), new DateTime(2020, 1, 17, 9, 47, 33, 860, DateTimeKind.Local).AddTicks(5931), "Admin@gmail.com", "Admin", "Admin", "Admin123!", "Admin" },
                    { 2, new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(808), new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(892), "Parent@gmail.com", "Parent", "Parent", "Parent123!", "Parent" },
                    { 3, new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(1325), new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(1344), "Student@gmail.com", "Student", "Student", "Student123!", "Student" },
                    { 4, new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(1416), new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(1426), "Teacher@gmail.com", "Teacher", "Teacher", "Teacher123!", "Teacher" },
                    { 5, new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(1491), new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(1503), "Student2@gmail.com", "Student2", "Student2", "Student123!", "Student" },
                    { 6, new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(1583), new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(1595), "Teacher2@gmail.com", "Teacher2", "Teacher2", "Teacher123!", "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[] { 1, new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(2852), new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(2885), 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(5766), new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(5801), 3 },
                    { 2, new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(9973), new DateTime(2020, 1, 17, 9, 47, 33, 865, DateTimeKind.Local).AddTicks(5), 5 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "ID", "DateCreated", "DateModified", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(8427), new DateTime(2020, 1, 17, 9, 47, 33, 864, DateTimeKind.Local).AddTicks(8460), 4 },
                    { 2, new DateTime(2020, 1, 17, 9, 47, 33, 865, DateTimeKind.Local).AddTicks(168), new DateTime(2020, 1, 17, 9, 47, 33, 865, DateTimeKind.Local).AddTicks(181), 6 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "ID", "DateCreated", "DateModified", "Score", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 17, 9, 47, 33, 865, DateTimeKind.Local).AddTicks(7723), new DateTime(2020, 1, 17, 9, 47, 33, 865, DateTimeKind.Local).AddTicks(7757), 5.0, 1, 1 },
                    { 2, new DateTime(2020, 1, 17, 9, 47, 33, 866, DateTimeKind.Local).AddTicks(1372), new DateTime(2020, 1, 17, 9, 47, 33, 866, DateTimeKind.Local).AddTicks(1407), 5.0, 2, 2 }
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

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentID",
                table: "Grades",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_SubjectID",
                table: "Grades",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudents_Parents_ParentID",
                table: "ParentStudents",
                column: "ParentID",
                principalTable: "Parents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudents_Students_StudentID",
                table: "ParentStudents",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectID",
                table: "TeacherSubjects",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherID",
                table: "TeacherSubjects",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_SubjectID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudents_Parents_ParentID",
                table: "ParentStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentStudents_Students_StudentID",
                table: "ParentStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectID",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherID",
                table: "TeacherSubjects");

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParentStudents",
                keyColumns: new[] { "ParentID", "StudentID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ParentStudents",
                keyColumns: new[] { "ParentID", "StudentID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "TeacherID", "SubjectID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "TeacherID", "SubjectID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "TeacherID", "SubjectID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectID",
                table: "Grades",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Grades",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentID",
                table: "Grades",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_SubjectID",
                table: "Grades",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudents_Parents_ParentID",
                table: "ParentStudents",
                column: "ParentID",
                principalTable: "Parents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentStudents_Students_StudentID",
                table: "ParentStudents",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectID",
                table: "TeacherSubjects",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherID",
                table: "TeacherSubjects",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
