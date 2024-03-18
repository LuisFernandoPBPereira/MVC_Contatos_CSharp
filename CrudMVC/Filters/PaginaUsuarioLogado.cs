using CrudMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace CrudMVC.Filters
{
    public class PaginaUsuarioLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Buscamos uma sessão de usuário
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            //Se nçao tiver sessão
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                //Redirecionamos o usuário para a página de login
                context.Result = new RedirectToRouteResult(new RouteValueDictionary 
                { 
                    { "controller", "Login" }, 
                    { "action", "Index" } 
                });
            }
            else
            {
                //Deserializamos o objeto usuário
                UsuarioModel usuario = JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);

                //Se for nulo
                if (usuario == null)
                {
                    //Redirecionamos o usuário para a página de login
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        { "controller", "Login" },
                        { "action", "Index" }
                    });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
