using CrudMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudMVC.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            //Instanciamos a HomeModel e atribuímos valores
            HomeModel home = new HomeModel();
            home.Nome = "Luis";
            home.Email = "luis@exemplo.com";
            
            //retornarmos a view passando o objeto home em parâmetro
            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
