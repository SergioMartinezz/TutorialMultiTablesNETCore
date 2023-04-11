using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorialMultiTablesNETCore.Migrations
{
    /// <inheritdoc />
    public partial class M4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alumnos",
                table: "Instructores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Alumnos",
                table: "Instructores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
