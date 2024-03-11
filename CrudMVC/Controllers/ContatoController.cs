using CrudMVC.Models;
using CrudMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        /*
            Abaixo estão as Views das respectivas funcionalidades do CRUD
         */

        //Listamos todos os contatos no frontend
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
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
                    //Adicionamos o contato criado no banco de dados
                    _contatoRepositorio.Adicionar(contato);
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
                    //Editamos o contato
                    _contatoRepositorio.Editar(contato);
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
}
