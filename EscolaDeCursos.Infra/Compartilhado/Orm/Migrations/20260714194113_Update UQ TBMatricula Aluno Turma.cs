using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUQTBMatriculaAlunoTurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_TBMatricula_Aluno_Turma_Ativa",
                table: "TBMatricula");

            migrationBuilder.CreateIndex(
                name: "UQ_TBMatricula_Aluno_Turma",
                table: "TBMatricula",
                columns: new[] { "AlunoId", "TurmaId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_TBMatricula_Aluno_Turma",
                table: "TBMatricula");

            migrationBuilder.CreateIndex(
                name: "UQ_TBMatricula_Aluno_Turma_Ativa",
                table: "TBMatricula",
                columns: new[] { "AlunoId", "TurmaId" },
                unique: true,
                filter: "[Situacao] = 0");
        }
    }
}
