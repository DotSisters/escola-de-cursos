using System.ComponentModel.DataAnnotations;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

public record OpcaoAlunoViewModel(
    Guid Id,
    string Nome
);

public record ListarMatriculasViewModel(
    Guid Id,
    Guid TurmaId,
    string AlunoNome,
    DateOnly Data,
    SituacaoAluno Situacao
);

public record CadastrarMatriculaViewModel(
    [Required(ErrorMessage = "O campo \"Aluno\" deve ser selecionado.")]
    Guid? AlunoId,

    Guid TurmaId,

    [ValidateNever]
    string TurmaNome,

    [ValidateNever]
    List<OpcaoAlunoViewModel> Alunos
);

public record EditarMatriculaViewModel(
    Guid Id,

    [ValidateNever]
    string AlunoNome,

    Guid TurmaId,

    [ValidateNever]
    string TurmaNome,

    [ValidateNever]
    DateOnly Data,

    [Required(ErrorMessage = "O campo \"Situação\" deve ser selecionado.")]
    SituacaoAluno Situacao
);
