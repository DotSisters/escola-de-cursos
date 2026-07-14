using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AddTBMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBTurmaAluno");

            migrationBuilder.CreateTable(
                name: "TBMatricula",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMatricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBMatricula_TBAluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "TBAluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBMatricula_TBTurma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "TBTurma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBMatricula_TurmaId",
                table: "TBMatricula",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "UQ_TBMatricula_Aluno_Turma_Ativa",
                table: "TBMatricula",
                columns: new[] { "AlunoId", "TurmaId" },
                unique: true,
                filter: "[Situacao] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBMatricula");

            migrationBuilder.CreateTable(
                name: "TBTurmaAluno",
                columns: table => new
                {
                    AlunosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTurmaAluno", x => new { x.AlunosId, x.TurmaId });
                    table.ForeignKey(
                        name: "FK_TBTurmaAluno_TBAluno_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "TBAluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBTurmaAluno_TBTurma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "TBTurma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBTurmaAluno_TurmaId",
                table: "TBTurmaAluno",
                column: "TurmaId");
        }
    }
}
