//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace Cinema.Persistence.Migrations
//{
//    /// <inheritdoc />
//    public partial class RenameMarkTable : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_Mark_Courses_CourseId",
//                table: "Mark");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Mark_Students_StudentId",
//                table: "Mark");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Mark_Teachers_TeacherId",
//                table: "Mark");

//            migrationBuilder.DropPrimaryKey(
//                name: "PK_Mark",
//                table: "Mark");

//            migrationBuilder.RenameTable(
//                name: "Mark",
//                newName: "Marks");

//            migrationBuilder.RenameIndex(
//                name: "IX_Mark_TeacherId",
//                table: "Marks",
//                newName: "IX_Marks_TeacherId");

//            migrationBuilder.RenameIndex(
//                name: "IX_Mark_StudentId",
//                table: "Marks",
//                newName: "IX_Marks_StudentId");

//            migrationBuilder.RenameIndex(
//                name: "IX_Mark_CourseId",
//                table: "Marks",
//                newName: "IX_Marks_CourseId");

//            migrationBuilder.AddPrimaryKey(
//                name: "PK_Marks",
//                table: "Marks",
//                column: "Id");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Marks_Courses_CourseId",
//                table: "Marks",
//                column: "CourseId",
//                principalTable: "Courses",
//                principalColumn: "Id");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Marks_Students_StudentId",
//                table: "Marks",
//                column: "StudentId",
//                principalTable: "Students",
//                principalColumn: "Id");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Marks_Teachers_TeacherId",
//                table: "Marks",
//                column: "TeacherId",
//                principalTable: "Teachers",
//                principalColumn: "Id");
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_Marks_Courses_CourseId",
//                table: "Marks");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Marks_Students_StudentId",
//                table: "Marks");

//            migrationBuilder.DropForeignKey(
//                name: "FK_Marks_Teachers_TeacherId",
//                table: "Marks");

//            migrationBuilder.DropPrimaryKey(
//                name: "PK_Marks",
//                table: "Marks");

//            migrationBuilder.RenameTable(
//                name: "Marks",
//                newName: "Mark");

//            migrationBuilder.RenameIndex(
//                name: "IX_Marks_TeacherId",
//                table: "Mark",
//                newName: "IX_Mark_TeacherId");

//            migrationBuilder.RenameIndex(
//                name: "IX_Marks_StudentId",
//                table: "Mark",
//                newName: "IX_Mark_StudentId");

//            migrationBuilder.RenameIndex(
//                name: "IX_Marks_CourseId",
//                table: "Mark",
//                newName: "IX_Mark_CourseId");

//            migrationBuilder.AddPrimaryKey(
//                name: "PK_Mark",
//                table: "Mark",
//                column: "Id");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Mark_Courses_CourseId",
//                table: "Mark",
//                column: "CourseId",
//                principalTable: "Courses",
//                principalColumn: "Id");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Mark_Students_StudentId",
//                table: "Mark",
//                column: "StudentId",
//                principalTable: "Students",
//                principalColumn: "Id");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Mark_Teachers_TeacherId",
//                table: "Mark",
//                column: "TeacherId",
//                principalTable: "Teachers",
//                principalColumn: "Id");
//        }
//    }
//}
