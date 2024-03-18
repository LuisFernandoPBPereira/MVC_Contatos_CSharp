using CrudMVC.Models;

namespace CrudMVC.Helper
{
    public interface ISessao
    {
        //Criamos os métodos da sessão do usuário
        void CriarSessaoDoUsuario(UsuarioModel usuarioModel);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
