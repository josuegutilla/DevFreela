using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevFreela.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeFkUserSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_habilidade_usuario_usuario_IdSkill",
                table: "habilidade_usuario");

            migrationBuilder.DropIndex(
                name: "IX_habilidade_usuario_IdSkill",
                table: "habilidade_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_habilidade_usuario_IdUser",
                table: "habilidade_usuario",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_habilidade_usuario_usuario_IdUser",
                table: "habilidade_usuario",
                column: "IdUser",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_habilidade_usuario_usuario_IdUser",
                table: "habilidade_usuario");

            migrationBuilder.DropIndex(
                name: "IX_habilidade_usuario_IdUser",
                table: "habilidade_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_habilidade_usuario_IdSkill",
                table: "habilidade_usuario",
                column: "IdSkill");

            migrationBuilder.AddForeignKey(
                name: "FK_habilidade_usuario_usuario_IdSkill",
                table: "habilidade_usuario",
                column: "IdSkill",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
