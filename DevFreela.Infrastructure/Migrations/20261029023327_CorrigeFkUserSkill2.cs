using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevFreela.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeFkUserSkill2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_habilidade_usuario_habilidade_SkillId",
                table: "habilidade_usuario");

            migrationBuilder.DropIndex(
                name: "IX_habilidade_usuario_SkillId",
                table: "habilidade_usuario");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "habilidade_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_habilidade_usuario_IdSkill",
                table: "habilidade_usuario",
                column: "IdSkill");

            migrationBuilder.AddForeignKey(
                name: "FK_habilidade_usuario_habilidade_IdSkill",
                table: "habilidade_usuario",
                column: "IdSkill",
                principalTable: "habilidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_habilidade_usuario_habilidade_IdSkill",
                table: "habilidade_usuario");

            migrationBuilder.DropIndex(
                name: "IX_habilidade_usuario_IdSkill",
                table: "habilidade_usuario");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "habilidade_usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_habilidade_usuario_SkillId",
                table: "habilidade_usuario",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_habilidade_usuario_habilidade_SkillId",
                table: "habilidade_usuario",
                column: "SkillId",
                principalTable: "habilidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
