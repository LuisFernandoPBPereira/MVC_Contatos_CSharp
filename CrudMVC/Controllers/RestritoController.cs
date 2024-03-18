using CrudMVC.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVC.Controllers;

[PaginaUsuarioLogado]
public class RestritoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
