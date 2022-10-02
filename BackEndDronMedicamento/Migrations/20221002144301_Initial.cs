using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndDronMedicamento.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drones",
                columns: table => new
                {
                    NumeroSerie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoLimite = table.Column<int>(type: "int", nullable: false),
                    CapacidadBateria = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drones", x => x.NumeroSerie);
                });

            migrationBuilder.CreateTable(
                name: "DronMedicamentos",
                columns: table => new
                {
                    CodigoMedicamento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodigoDron = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DronMedicamentos", x => x.CodigoMedicamento);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drones");

            migrationBuilder.DropTable(
                name: "DronMedicamentos");

            migrationBuilder.DropTable(
                name: "Medicamentos");
        }
    }
}
