using CrudMVC.Filters;
using CrudMVC.Helper;
using CrudMVC.Models;
using CrudMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVC.Controllers;

//Determinamos que está página será acessada apenas quando o usuário estiver logado
[PaginaUsuarioLogado]
public class ContatoController : Controller
{
    private readonly IContatoRepositorio _contatoRepositorio;
    private readonly ISessao _sessao;
    public ContatoController(IContatoRepositorio contatoRepositorio,
                             ISessao sessao)
    {
        _contatoRepositorio = contatoRepositorio;
        _sessao = sessao;
    }
    /*
        Abaixo estão as Views das respectivas funcionalidades do CRUD
     */

    //Listamos todos os contatos no frontend
    public IActionResult Index()
    {
        UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
        List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos(usuarioLogado.Id);
        return View(contatos);
    }
    public IActionResult Criar()
    {
        return View();
    }
    //É invocado o método para buscar um usuário por ID
    public IActionResult Editar(int id)
    {
        ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
        return View(contato);
    }
    public IActionResult ApagarConfirmacao(int id)
    {
        ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
        return View(contato);
    }

    /*
     * ----------------------- MÉTODOS HTTP -------------------------
    */

    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
        try
        {
            //Se o estado da ContatoModel é válida
            if (ModelState.IsValid)
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                contato.UsuarioId = usuarioLogado.Id;
                //Adicionamos o contato criado no banco de dados
                contato = _contatoRepositorio.Adicionar(contato);
                //Usamos uma variável temporária para exibir um alerta
                TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(contato);
        }
        catch (Exception e)
        {
            //Tratativa de erro
            TempData["MensagemErro"] = $"Não foi possível cadastrar seu contato, tente novamente! Detalhe do erro {e.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Editar(ContatoModel contato)
    {
        try
        {
            //Se o estado da ContatoModel é válida
            if (ModelState.IsValid)
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                contato.UsuarioId = usuarioLogado.Id;
                //Editamos o contato
                contato = _contatoRepositorio.Editar(contato);
                //Usamos uma variável temporária para exibir um alerta
                TempData["MensagemSucesso"] = "Contato editado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(contato);
        }
        catch (Exception e)
        {
            //Tratativa de erro
            TempData["MensagemErro"] = $"Não foi possível editar seu contato, tente novamente! Detalhe do erro {e.Message}";
            return RedirectToAction("Index");
        }
    }
    
    public IActionResult Apagar(int id)
    {
        try
        {
            //Apagamos o contato pelo ID
            _contatoRepositorio.Apagar(id);
            //Usamos uma variável temporária para exibir um alerta
            TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            //Tratativa de erro
            TempData["MensagemErro"] = $"Não foi possível apagar seu contato, tente novamente! Detalhe do erro {e.Message}";
            return RedirectToAction("Index");
        }
    }
}
