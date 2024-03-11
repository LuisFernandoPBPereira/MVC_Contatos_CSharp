using CrudMVC.Models;

namespace CrudMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        //Definimos a interface do usuário
        UsuarioModel BuscarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel contato);
        UsuarioModel Editar(UsuarioModel contato);
        bool Apagar(int id);
    }
}
