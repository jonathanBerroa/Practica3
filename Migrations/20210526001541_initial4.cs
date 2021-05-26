using Microsoft.EntityFrameworkCore.Migrations;

namespace Practica3.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Productos_producId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Compradores_Compras_SolicitudId",
                table: "Compradores");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_producId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "producId",
                table: "Categorias");

            migrationBuilder.RenameColumn(
                name: "SolicitudId",
                table: "Compradores",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Compradores_SolicitudId",
                table: "Compradores",
                newName: "IX_Compradores_CategoriaId");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Compradores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Precio",
                table: "Compradores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Compradores_Categorias_CategoriaId",
                table: "Compradores",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compradores_Categorias_CategoriaId",
                table: "Compradores");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Compradores");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Compradores");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Compradores",
                newName: "SolicitudId");

            migrationBuilder.RenameIndex(
                name: "IX_Compradores_CategoriaId",
                table: "Compradores",
                newName: "IX_Compradores_SolicitudId");

            migrationBuilder.AddColumn<int>(
                name: "producId",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Categorias_CategId",
                        column: x => x.CategId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_producId",
                table: "Categorias",
                column: "producId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CategId",
                table: "Compras",
                column: "CategId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Productos_producId",
                table: "Categorias",
                column: "producId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compradores_Compras_SolicitudId",
                table: "Compradores",
                column: "SolicitudId",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
