using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiEmpleado.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pais = table.Column<string>(type: "varchar(100)", nullable: false),
                    Provincia = table.Column<string>(type: "varchar(100)", nullable: false),
                    Sector = table.Column<string>(type: "varchar(100)", nullable: false),
                    Calle = table.Column<string>(type: "varchar(100)", nullable: false),
                    NumeroCasa = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(100)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cargo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Departamento = table.Column<string>(type: "varchar(100)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    DireccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Direcciones_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direcciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_Id",
                table: "Direcciones",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_DireccionId",
                table: "Empleados",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Id",
                table: "Empleados",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Direcciones");
        }
    }
}
