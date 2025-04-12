using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminUsuariosApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDepartamento = table.Column<int>(type: "int", nullable: true),
                    IdCargo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cargos_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_Departamentos_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "Activo", "Codigo", "IdUsuarioCreacion", "Nombre" },
                values: new object[] { 1, true, "CAR001", 1, "Programador" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Activo", "Codigo", "IdUsuarioCreacion", "Nombre" },
                values: new object[] { 1, true, "DEP001", 1, "Sistemas" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IdCargo", "IdDepartamento", "PrimerApellido", "PrimerNombre", "SegundoApellido", "SegundoNombre", "Usuario" },
                values: new object[] { 1, 1, 1, "Andrade", "Steven", "Salazar", "Fernando", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdCargo",
                table: "Users",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdDepartamento",
                table: "Users",
                column: "IdDepartamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
