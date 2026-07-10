using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using FluentResults;
namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;

public class ServicoCategoria : ServicoBase<Categoria>
{
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCategoria(
        IRepositorioCategoria repositorioCategoria
    )
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public List<ListarCategoriasDto> SelecionarTodos()
    {
        return repositorioCategoria
            .SelecionarTodos()
            .Select(c => new ListarCategoriasDto(
                c.Id,
                c.Titulo
            ))
            .ToList();
    }

    public Result Cadastrar(CadastrarCategoriaDto dto)
    {
        if (ExisteCategoriaComMesmoTitulo(dto.Titulo))
            return Falha(nameof(dto.Titulo), "Já existe uma categoria com este título.");

        Categoria novaCategoria = new Categoria(dto.Titulo);

        Result resultadoValidacao = ValidarEntidade(novaCategoria);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioCategoria.Cadastrar(novaCategoria);

        return Result.Ok();
    }

    private bool ExisteCategoriaComMesmoTitulo(string titulo, Guid? idIgnorado = null)
    {
        string tituloNormalizado = NormalizarTitulo(titulo);

        return repositorioCategoria
            .SelecionarTodos()
            .Any(c =>
                c.Id != idIgnorado &&
                NormalizarTitulo(c.Titulo) == tituloNormalizado
            );
    }

    private static string NormalizarTitulo(string titulo)
    {
        return titulo.Trim().ToLowerInvariant();
    }

}
