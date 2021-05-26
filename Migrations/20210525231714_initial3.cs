using Microsoft.EntityFrameworkCore.Migrations;

namespace Practica3.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SolicitudId",
                table: "Compradores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "producId",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CategId",
                table: "Compras",
                column: "CategId");

            migrationBuilder.CreateIndex(
                name: "IX_Compradores_SolicitudId",
                table: "Compradores",
                column: "SolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_producId",
                table: "Categorias",
                column: "producId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Categorias_CategId",
                table: "Compras",
                column: "CategId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Productos_producId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Compradores_Compras_SolicitudId",
                table: "Compradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Categorias_CategId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_CategId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compradores_SolicitudId",
                table: "Compradores");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_producId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "CategId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "SolicitudId",
                table: "Compradores");

            migrationBuilder.DropColumn(
                name: "producId",
                table: "Categorias");
        }
    }
}
