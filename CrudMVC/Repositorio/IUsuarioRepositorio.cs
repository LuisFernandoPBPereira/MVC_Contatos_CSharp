using CrudMVC.Models;

namespace CrudMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        //Definimos a interface do usuário
        UsuarioModel BuscarPorId(int id);
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel contato);
        UsuarioModel Editar(UsuarioModel contato);
        bool Apagar(int id);
    }
}
