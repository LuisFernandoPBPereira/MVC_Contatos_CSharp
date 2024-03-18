using CrudMVC.Models;
using System.Text.Json;

namespace CrudMVC.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public UsuarioModel BuscarSessaoDoUsuario()
        {
            //Busca a sessão do usuário
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            //Se não houver sessão, retonra null
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            //Se tiver sessão, retorna a sessão deserializada
            return JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuarioModel)
        {
            //Serializamos o objeto usuarioModel para um json string, e passamos o nome da sessao no contexto http
            string valor = JsonSerializer.Serialize(usuarioModel);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
