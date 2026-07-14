using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso.ModuloModulo;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso.ModuloModulo;

public class ModuloController(
    ServicoModulo servicoModulo,
    ServicoCurso servicoCurso,
    IMapper mapeador) : Controller
{

    [HttpGet]
    public ActionResult Listar(Guid cursoId)
    {
        List<ListarModulosDto> dtos = servicoModulo.SelecionarPorCurso(cursoId);
        List<ListarModulosViewModel> vms = mapeador.Map<List<ListarModulosViewModel>>(dtos);

        ViewBag.CursoId = cursoId;
        ViewBag.CursoTitulo = servicoCurso.SelecionarPorId(cursoId).ValueOrDefault?.Titulo;

        return View(vms);
    }

    [HttpGet]
    public ActionResult Cadastrar(Guid id)
    {
        Result<DetalhesCursoDto> resultado = servicoCurso.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar), new { cursoId = id });
        }

        CadastrarModuloViewModel cadastrarVm = new(string.Empty, string.Empty, 0, 0, id);

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarModuloViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarModuloDto dto = mapeador.Map<CadastrarModuloDto>(cadastrarVm);

        Result resultado = servicoModulo.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar), new { cursoId = cadastrarVm.CursoId });
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesModuloDto> resultado = servicoModulo.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar), new { cursoId = resultado.ValueOrDefault?.CursoId });
        }

        EditarModuloViewModel editarVm = mapeador.Map<EditarModuloViewModel>(resultado.Value);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarModuloViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarModuloDto dto = mapeador.Map<EditarModuloDto>(editarVm);

        Result resultado = servicoModulo.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar), new { cursoId = editarVm.CursoId });
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesModuloDto> resultado = servicoModulo.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar), new { cursoId = resultado.ValueOrDefault?.CursoId });
        }

        ExcluirModuloViewModel excluirVm = mapeador.Map<ExcluirModuloViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirModuloViewModel excluirVm)
    {
        Result resultado = servicoModulo.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar), new { cursoId = excluirVm.CursoId });
    }
}
