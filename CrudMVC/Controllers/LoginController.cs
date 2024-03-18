using CrudMVC.Helper;
using CrudMVC.Models;
using CrudMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVC.Controllers;

public class LoginController : Controller
{
    //Fazemos a injeção de dependências
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly ISessao _sessao;
    public LoginController(IUsuarioRepositorio usuarioRepositorio,
                           ISessao sessao)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _sessao = sessao;
    }
    public IActionResult Index()
    {
        //Se o usuário estivar logado, redirecionar para a home
        if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

        return View();
    }

    public IActionResult Sair()
    {
        //Remove a sessão do usuárioa o clicar no botão de sair
        _sessao.RemoverSessaoDoUsuario();
        return RedirectToAction("Index", "Login");
    }

    [HttpPost]
    public IActionResult Entrar(LoginModel loginModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                //Buscamos o login informado
                UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                if(usuario != null)
                {
                    //Comparamos a senha informada com a senha do banco de dados
                    if (usuario.SenhaValida(loginModel.Senha))
                    {
                        //Criamos a sessão do usuário
                        _sessao.CriarSessaoDoUsuario(usuario);
                        //Se o login for bem sucedido, o uusário é redirecionado para a home
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente!";
                }
            }

            return View("Index");
        }
        catch (Exception e)
        {
            TempData["MensagemErro"] = $"Não foi possível realizar o login: {e.Message}";
            return RedirectToAction("Index");
        }
    }
}
