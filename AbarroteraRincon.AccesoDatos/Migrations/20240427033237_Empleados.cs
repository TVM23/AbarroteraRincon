using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbarroteraRincon.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class Empleados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PuestoId = table.Column<int>(type: "int", nullable: false),
                    AreaPId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_AreasP_AreaPId",
                        column: x => x.AreaPId,
                        principalTable: "AreasP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Empleados_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_AreaPId",
                table: "Empleados",
                column: "AreaPId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PuestoId",
                table: "Empleados",
                column: "PuestoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
