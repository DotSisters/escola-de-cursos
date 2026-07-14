using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso.ModuloModulo;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso.ModuloModulo;

public class ServicoModulo : ServicoBase<Modulo>
{
    private readonly IRepositorioModulo repositorioModulo;
    private readonly IRepositorioCurso repositorioCurso;

    public ServicoModulo(
        IRepositorioModulo repositorioModulo,
        IRepositorioCurso repositorioCurso
    )
    {
        this.repositorioModulo = repositorioModulo;
        this.repositorioCurso = repositorioCurso;
    }

    public Result Cadastrar(CadastrarModuloDto dto)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(dto.CursoId);

        if (curso == null)
            return Falha(nameof(dto.CursoId), "Curso não encontrado.");

        if (ExisteModuloComMesmaOrdem(dto.CursoId, dto.Ordem))
            return Falha(nameof(dto.Ordem), "Já existe um módulo com esta ordem neste curso.");

        Modulo novoModulo = new Modulo(
            dto.Titulo,
            dto.Descricao,
            dto.Ordem,
            dto.Duracao,
            curso
        );

        Result resultadoValidacao = ValidarEntidade(novoModulo);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioModulo.Cadastrar(novoModulo);

        return Result.Ok();
    }

    public Result Editar(EditarModuloDto dto)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(dto.CursoId);

        if (curso == null)
            return Falha(nameof(dto.CursoId), "Curso não encontrado.");

        if (ExisteModuloComMesmaOrdem(dto.CursoId, dto.Ordem, dto.Id))
            return Falha(nameof(dto.Ordem), "Já existe um módulo com esta ordem neste curso.");

        Modulo moduloAtualizado = new Modulo(
            dto.Titulo,
            dto.Descricao,
            dto.Ordem,
            dto.Duracao,
            curso
        );

        Result resultadoValidacao = ValidarEntidade(moduloAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioModulo.Editar(dto.Id, moduloAtualizado);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Módulo não encontrado.");

        return Result.Ok();
    }

    public Result<DetalhesModuloDto> SelecionarPorId(Guid id)
    {
        Modulo? modulo = repositorioModulo.SelecionarPorId(id);

        if (modulo == null)
            return Result.Fail("Módulo não encontrado.");

        return Result.Ok(new DetalhesModuloDto(
            modulo.Id,
            modulo.Titulo,
            modulo.Descricao,
            modulo.Ordem,
            modulo.Duracao,
            modulo.CursoId,
            modulo.Curso.Titulo
        ));
    }

    public Result Excluir(Guid id)
    {
        Modulo? modulo = repositorioModulo.SelecionarPorId(id);

        if (modulo == null)
            return Falha(string.Empty, "Módulo não encontrado.");

        repositorioModulo.Excluir(id);

        return Result.Ok();
    }

    public List<ListarModulosDto> SelecionarPorCurso(Guid cursoId)
    {
        return repositorioModulo
            .SelecionarTodos()
            .Where(m => m.CursoId == cursoId)
            .Select(m => new ListarModulosDto(
                m.Id,
                m.Titulo,
                m.Descricao,
                m.Ordem,
                m.Duracao,
                m.CursoId,
                m.Curso.Titulo
            ))
            .ToList();
    }

    private bool ExisteModuloComMesmaOrdem(Guid cursoId, int ordem, Guid? idIgnorado = null)
    {
        return repositorioModulo
            .SelecionarTodos()
            .Any(m =>
                m.Id != idIgnorado &&
                m.CursoId == cursoId &&
                m.Ordem == ordem
            );
    }
}
