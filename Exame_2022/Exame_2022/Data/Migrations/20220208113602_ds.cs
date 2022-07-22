using Microsoft.EntityFrameworkCore.Migrations;

namespace Exame_2022.Data.Migrations
{
    public partial class ds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Download_Documento_PaisID",
                table: "Download");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Download",
                table: "Download");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documento",
                table: "Documento");

            migrationBuilder.RenameTable(
                name: "Download",
                newName: "Empresas");

            migrationBuilder.RenameTable(
                name: "Documento",
                newName: "Paises");

            migrationBuilder.RenameIndex(
                name: "IX_Download_PaisID",
                table: "Empresas",
                newName: "IX_Empresas_PaisID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paises",
                table: "Paises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Paises_PaisID",
                table: "Empresas",
                column: "PaisID",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Paises_PaisID",
                table: "Empresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paises",
                table: "Paises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas");

            migrationBuilder.RenameTable(
                name: "Paises",
                newName: "Documento");

            migrationBuilder.RenameTable(
                name: "Empresas",
                newName: "Download");

            migrationBuilder.RenameIndex(
                name: "IX_Empresas_PaisID",
                table: "Download",
                newName: "IX_Download_PaisID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documento",
                table: "Documento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Download",
                table: "Download",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Download_Documento_PaisID",
                table: "Download",
                column: "PaisID",
                principalTable: "Documento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
