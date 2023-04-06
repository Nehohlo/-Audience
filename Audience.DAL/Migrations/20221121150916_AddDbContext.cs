using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Audience.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_TimetableOfClasses_timetableOfClassesid",
                table: "Class");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TimetableOfClasses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "timetableOfClassesid",
                table: "Class",
                newName: "timetableOfClassesId");

            migrationBuilder.RenameIndex(
                name: "IX_Class_timetableOfClassesid",
                table: "Class",
                newName: "IX_Class_timetableOfClassesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_TimetableOfClasses_timetableOfClassesId",
                table: "Class",
                column: "timetableOfClassesId",
                principalTable: "TimetableOfClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_TimetableOfClasses_timetableOfClassesId",
                table: "Class");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TimetableOfClasses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "timetableOfClassesId",
                table: "Class",
                newName: "timetableOfClassesid");

            migrationBuilder.RenameIndex(
                name: "IX_Class_timetableOfClassesId",
                table: "Class",
                newName: "IX_Class_timetableOfClassesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_TimetableOfClasses_timetableOfClassesid",
                table: "Class",
                column: "timetableOfClassesid",
                principalTable: "TimetableOfClasses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
