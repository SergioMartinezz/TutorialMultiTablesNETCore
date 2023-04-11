using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorialMultiTablesNETCore.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Alumnos_AlumnoId",
                table: "Actividades");

            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Instructores_InstructorId",
                table: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_AlumnoId",
                table: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_InstructorId",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Actividades");

            migrationBuilder.AddColumn<int>(
                name: "ActividadId",
                table: "Instructores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Alumnos",
                table: "Instructores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    MatriculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoId = table.Column<int>(type: "int", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.MatriculaId);
                    table.ForeignKey(
                        name: "FK_Matriculas_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "ActividadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "AlumnoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructores_ActividadId",
                table: "Instructores",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_ActividadId",
                table: "Matriculas",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AlumnoId",
                table: "Matriculas",
                column: "AlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructores_Actividades_ActividadId",
                table: "Instructores",
                column: "ActividadId",
                principalTable: "Actividades",
                principalColumn: "ActividadId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructores_Actividades_ActividadId",
                table: "Instructores");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Instructores_ActividadId",
                table: "Instructores");

            migrationBuilder.DropColumn(
                name: "ActividadId",
                table: "Instructores");

            migrationBuilder.DropColumn(
                name: "Alumnos",
                table: "Instructores");

            migrationBuilder.AddColumn<int>(
                name: "AlumnoId",
                table: "Actividades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Actividades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_AlumnoId",
                table: "Actividades",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_InstructorId",
                table: "Actividades",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Alumnos_AlumnoId",
                table: "Actividades",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "AlumnoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Instructores_InstructorId",
                table: "Actividades",
                column: "InstructorId",
                principalTable: "Instructores",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
