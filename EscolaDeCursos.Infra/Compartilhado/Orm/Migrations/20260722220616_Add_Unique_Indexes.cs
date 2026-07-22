using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_Unique_Indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_TBModulo_Curso_Ordem",
                table: "TBModulo");

            migrationBuilder.DropIndex(
                name: "UQ_TBMatricula_Aluno_Turma",
                table: "TBMatricula");

            migrationBuilder.DropIndex(
                name: "UQ_TBInstrutor_Cpf",
                table: "TBInstrutor");

            migrationBuilder.DropIndex(
                name: "UQ_TBInstrutor_Email",
                table: "TBInstrutor");

            migrationBuilder.DropIndex(
                name: "UQ_TBCurso_Titulo",
                table: "TBCurso");

            migrationBuilder.DropIndex(
                name: "UQ_TBCategoria_Titulo",
                table: "TBCategoria");

            migrationBuilder.CreateIndex(
                name: "UQ_TBTurma_UserId_Nome_DataInicio_DataTermino",
                table: "TBTurma",
                columns: new[] { "UserId", "Nome", "DataInicio", "DataTermino" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBModulo_CursoId",
                table: "TBModulo",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "UQ_TBModulo_UserId_Curso_Ordem",
                table: "TBModulo",
                columns: new[] { "UserId", "CursoId", "Ordem" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBMatricula_AlunoId",
                table: "TBMatricula",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "UQ_TBMatricula_UserId_Aluno_Turma",
                table: "TBMatricula",
                columns: new[] { "UserId", "AlunoId", "TurmaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBInstrutor_UserId_Cpf",
                table: "TBInstrutor",
                columns: new[] { "UserId", "Cpf" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBInstrutor_UserId_Email",
                table: "TBInstrutor",
                columns: new[] { "UserId", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBInstituicao_UserId_Nome",
                table: "TBInstituicao",
                columns: new[] { "UserId", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBCurso_UserId_Titulo",
                table: "TBCurso",
                columns: new[] { "UserId", "Titulo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBCategoria_UserId_Titulo",
                table: "TBCategoria",
                columns: new[] { "UserId", "Titulo" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_TBTurma_UserId_Nome_DataInicio_DataTermino",
                table: "TBTurma");

            migrationBuilder.DropIndex(
                name: "IX_TBModulo_CursoId",
                table: "TBModulo");

            migrationBuilder.DropIndex(
                name: "UQ_TBModulo_UserId_Curso_Ordem",
                table: "TBModulo");

            migrationBuilder.DropIndex(
                name: "IX_TBMatricula_AlunoId",
                table: "TBMatricula");

            migrationBuilder.DropIndex(
                name: "UQ_TBMatricula_UserId_Aluno_Turma",
                table: "TBMatricula");

            migrationBuilder.DropIndex(
                name: "UQ_TBInstrutor_UserId_Cpf",
                table: "TBInstrutor");

            migrationBuilder.DropIndex(
                name: "UQ_TBInstrutor_UserId_Email",
                table: "TBInstrutor");

            migrationBuilder.DropIndex(
                name: "UQ_TBInstituicao_UserId_Nome",
                table: "TBInstituicao");

            migrationBuilder.DropIndex(
                name: "UQ_TBCurso_UserId_Titulo",
                table: "TBCurso");

            migrationBuilder.DropIndex(
                name: "UQ_TBCategoria_UserId_Titulo",
                table: "TBCategoria");

            migrationBuilder.CreateIndex(
                name: "UQ_TBModulo_Curso_Ordem",
                table: "TBModulo",
                columns: new[] { "CursoId", "Ordem" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBMatricula_Aluno_Turma",
                table: "TBMatricula",
                columns: new[] { "AlunoId", "TurmaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBInstrutor_Cpf",
                table: "TBInstrutor",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBInstrutor_Email",
                table: "TBInstrutor",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBCurso_Titulo",
                table: "TBCurso",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TBCategoria_Titulo",
                table: "TBCategoria",
                column: "Titulo",
                unique: true);
        }
    }
}
