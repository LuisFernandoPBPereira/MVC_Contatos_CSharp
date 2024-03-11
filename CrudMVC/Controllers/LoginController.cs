using CrudMVC.Models;
using CrudMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVC.Controllers
{
    public class LoginController : Controller
    {
        //Fazemos a injeção de dependências
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
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
}
