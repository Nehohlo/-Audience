using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Audience.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Class");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Class",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "timetableOfClassesid",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TimetableOfClasses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeEnd = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimetableOfClasses", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_timetableOfClassesid",
                table: "Class",
                column: "timetableOfClassesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_TimetableOfClasses_timetableOfClassesid",
                table: "Class",
                column: "timetableOfClassesid",
                principalTable: "TimetableOfClasses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_TimetableOfClasses_timetableOfClassesid",
                table: "Class");

            migrationBuilder.DropTable(
                name: "TimetableOfClasses");

            migrationBuilder.DropIndex(
                name: "IX_Class_timetableOfClassesid",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "timetableOfClassesid",
                table: "Class");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Class",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
