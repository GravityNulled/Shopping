using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsApi.Migrations
{
    public partial class updateddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerApplications",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Csharp",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "DataBase",
                table: "Units");

            migrationBuilder.RenameColumn(
                name: "Mathematics",
                table: "Units",
                newName: "CourseName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Units",
                newName: "Mathematics");

            migrationBuilder.AddColumn<string>(
                name: "ComputerApplications",
                table: "Units",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Csharp",
                table: "Units",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataBase",
                table: "Units",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
