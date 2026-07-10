using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutor;

public class InstrutorController(ServicoInstrutor servicoInstrutor, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarInstrutoresDto> dtos = servicoInstrutor.SelecionarTodos();
        List<ListarInstrutoresViewModel> listarVms = mapeador.Map<List<ListarInstrutoresViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarInstrutorViewModel cadastrarVm = new CadastrarInstrutorViewModel(
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarInstrutorViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarInstrutorDto dto = mapeador.Map<CadastrarInstrutorDto>(cadastrarVm);

        Result resultado = servicoInstrutor.Cadastrar(dto);


        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }
}