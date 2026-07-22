using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_Aluno_Unique_Indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_TBAluno_Cpf",
                table: "TBAluno");

            migrationBuilder.DropIndex(
                name: "UQ_TBAluno_Email",
                table: "TBAluno");

            migrationBuilder.CreateIndex(
                name: "UQ_TBAluno_UserId_Cpf",
                table: "TBAluno",
                columns: new[] { "UserId", "Cpf" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBAluno_UserId_Email",
                table: "TBAluno",
                columns: new[] { "UserId", "Email" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_TBAluno_UserId_Cpf",
                table: "TBAluno");

            migrationBuilder.DropIndex(
                name: "UQ_TBAluno_UserId_Email",
                table: "TBAluno");

            migrationBuilder.CreateIndex(
                name: "UQ_TBAluno_Cpf",
                table: "TBAluno",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBAluno_Email",
                table: "TBAluno",
                column: "Email",
                unique: true);
        }
    }
}
