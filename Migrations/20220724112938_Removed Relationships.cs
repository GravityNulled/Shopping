using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsApi.Migrations
{
    public partial class RemovedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IDNumber_Students_StudentId",
                table: "IDNumber");

            migrationBuilder.DropTable(
                name: "StudentUnit");

            migrationBuilder.DropTable(
                name: "TeacherUnit");

            migrationBuilder.DropIndex(
                name: "IX_IDNumber_StudentId",
                table: "IDNumber");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "IDNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "IDNumber",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentUnit",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUnit", x => new { x.StudentsId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_StudentUnit_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentUnit_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherUnit",
                columns: table => new
                {
                    TeachersId = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherUnit", x => new { x.TeachersId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_TeacherUnit_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherUnit_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IDNumber_StudentId",
                table: "IDNumber",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentUnit_UnitsId",
                table: "StudentUnit",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherUnit_UnitsId",
                table: "TeacherUnit",
                column: "UnitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_IDNumber_Students_StudentId",
                table: "IDNumber",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
