using CrudMVC.Filters;
using CrudMVC.Models;
using CrudMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVC.Controllers;

//Determinamos que está página será acessada apenas quando o usuário estiver logado e ser perfil admin
[PaginaRestritaAdmin]
public class UsuarioController : Controller
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IContatoRepositorio _contatoRepositorio;
    public UsuarioController(IUsuarioRepositorio usuarioRepositorio,
                             IContatoRepositorio contatoRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _contatoRepositorio = contatoRepositorio;
    }
    /*
        Abaixo estão as Views das respectivas funcionalidades do CRUD
     */

    //Listamos todos os contatos no frontend
    public IActionResult Index()
    {
        List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
        return View(usuarios);
    }
    public IActionResult Criar()
    {
        return View();
    }
    //É invocado o método para buscar um usuário por ID
    public IActionResult Editar(int id)
    {
        UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(id);
        return View(usuario);
    }
    public IActionResult ApagarConfirmacao(int id)
    {
        UsuarioModel usuario = _usuarioRepositorio.BuscarPorId(id);
        return View(usuario);
    }

    /*
     * ----------------------- MÉTODOS HTTP -------------------------
    */

    [HttpGet]
    public IActionResult ListarContatosPorUsuarioId(int id)
    {
        List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos(id);
        return PartialView("_ContatosUsuario", contatos);
    }

    [HttpPost]
    public IActionResult Criar(UsuarioModel usuario)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.Adicionar(usuario);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
        catch (Exception e)
        {
            TempData["MensagemErro"] = $"Não foi possível cadastrar seu usuário, tente novamente! Detalhe do erro {e.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
    {
        try
        {
            UsuarioModel usuario = null;
            if (ModelState.IsValid)
            {
                usuario = new UsuarioModel()
                {
                    Id = usuarioSemSenhaModel.Id,
                    Nome = usuarioSemSenhaModel.Nome,
                    Login = usuarioSemSenhaModel.Login,
                    Email = usuarioSemSenhaModel.Email,
                    Perfil = usuarioSemSenhaModel.Perfil
                };
                usuario =  _usuarioRepositorio.Editar(usuario);
                TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
        catch (Exception e)
        {
            TempData["MensagemErro"] = $"Não foi possível editar seu usuário, tente novamente! Detalhe do erro {e.Message}";
            return RedirectToAction("Index");
        }
    }

    public IActionResult Apagar(int id)
    {
        try
        {
            _usuarioRepositorio.Apagar(id);
            TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["MensagemErro"] = $"Não foi possível apagar seu usuário, tente novamente! Detalhe do erro {e.Message}";
            return RedirectToAction("Index");
        }
    }
}
