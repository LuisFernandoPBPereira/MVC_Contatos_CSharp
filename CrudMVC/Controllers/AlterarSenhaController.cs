using CrudMVC.Helper;
using CrudMVC.Models;
using CrudMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVC.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio,
                                      ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                //Buscamos a sessão do usuário para pegarmos seu ID
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;
                
                if (ModelState.IsValid)
                {
                    //Chamamos o método de alterar senha
                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = $"Senha alterada com sucesso!";

                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar sua senha, tente novamente! Detalhe do erro: {ex.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
