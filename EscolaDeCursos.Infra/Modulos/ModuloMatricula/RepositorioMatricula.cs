using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloMatricula;

public sealed class RepositorioMatricula(EscolaDeCursosDbContext dbContext) :
    RepositorioBase<Matricula>(dbContext), IRepositorioMatricula
{
    public override Matricula? SelecionarPorId(Guid idSelecionado)
    {
        return registros
            .Include(m => m.Aluno)
            .Include(m => m.Turma)
            .SingleOrDefault(m => m.Id == idSelecionado);
    }

    public override List<Matricula> SelecionarTodos()
    {
        return registros
            .Include(m => m.Aluno)
            .Include(m => m.Turma)
            .OrderByDescending(m => m.Data)
            .ToList();
    }
}
