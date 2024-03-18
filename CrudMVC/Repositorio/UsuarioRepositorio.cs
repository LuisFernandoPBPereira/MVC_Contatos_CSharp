using CrudMVC.Data;
using CrudMVC.Models;

namespace CrudMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        //Fazemos a injeção do contexto no construtor
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        //Adicionamos na tabela Contatos e salvamos as alterações
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            //Chamamos o método para criptografar a senha
            usuario.SetSenhaHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }

        public bool Apagar(int id)
        {
            UsuarioModel contatoDb = BuscarPorId(id);

            //Se o contato buscado não existir
            if (contatoDb == null)
            {
                throw new Exception("Houve um erro na deleção do usuário!");
            }

            _bancoContext.Usuarios.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;
        }

        /*
         * Ao buscar por ID, pegamos o primeiro ou o padrão pelo ID passado, 
         * e compararmos com o existente no banco 
        */
        public UsuarioModel BuscarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());

        }

        //Aqui listamos retornamos a listagem de todos os usuários
        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        //Buscamos o usuário por Id e retornamos
        public UsuarioModel Editar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = BuscarPorId(usuario.Id);

            //Se o contato buscado não existir
            if (usuarioDb == null)
            {
                throw new Exception("Contato inexistente!");
            }

            //Caso o usuário exista, são atribuídos os novos valores
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.Now;

            //Atualizamos e salvamos
            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();

            return usuarioDb;
        }
    }
}
