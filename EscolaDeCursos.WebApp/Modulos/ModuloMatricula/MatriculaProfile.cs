using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

namespace EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

public class MatriculaProfile : Profile
{
    public MatriculaProfile()
    {
        CreateMap<ListarMatriculasDto, ListarMatriculasViewModel>();
        CreateMap<CadastrarMatriculaViewModel, CadastrarMatriculaDto>()
            .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.AlunoId!.Value));
        CreateMap<EditarMatriculaViewModel, EditarMatriculaDto>();
        CreateMap<DetalhesMatriculaDto, EditarMatriculaViewModel>();
        CreateMap<OpcaoAlunoDto, OpcaoAlunoViewModel>();
    }
}
