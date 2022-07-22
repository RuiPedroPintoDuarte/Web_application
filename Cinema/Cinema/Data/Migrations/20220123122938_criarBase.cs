using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Data.Migrations
{
    public partial class criarBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horario_Filmes_FilmeId",
                table: "Horario");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Horario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Horario_Filmes_FilmeId",
                table: "Horario",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horario_Filmes_FilmeId",
                table: "Horario");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Horario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Horario_Filmes_FilmeId",
                table: "Horario",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
