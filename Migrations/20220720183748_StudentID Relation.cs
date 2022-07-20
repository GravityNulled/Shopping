using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsApi.Migrations
{
    public partial class StudentIDRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "IDNumber",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IDNumber_StudentId",
                table: "IDNumber",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IDNumber_Students_StudentId",
                table: "IDNumber",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IDNumber_Students_StudentId",
                table: "IDNumber");

            migrationBuilder.DropIndex(
                name: "IX_IDNumber_StudentId",
                table: "IDNumber");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "IDNumber");
        }
    }
}
