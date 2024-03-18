using CrudMVC.Data;
using CrudMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        //Criamos a variável de contexto do banco globalmente
        private readonly BancoContext _bancoContext;

        //Fazemos a injeção do contexto no construtor
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        //Adicionamos na tabela Contatos e salvamos as alterações
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = BuscarPorId(id);

            //Se o contato buscado não existir
            if (contatoDb == null)
            {
                throw new Exception("Houve um erro na deleção do usuário!");
            }

            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;
        }

        /*
         * Ao buscar por ID, pegamos o primeiro ou o padrão pelo ID passado, 
         * e compararmos com o existente no banco 
        */
        public ContatoModel BuscarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        //Aqui listamos retornamos a listagem de todos os usuários
        public List<ContatoModel> BuscarTodos(int usuarioId)
        {
            return _bancoContext.Contatos.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        //Buscamos o usuário por Id e retornamos
        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel contatoDb = BuscarPorId(contato.Id);
            
            //Se o contato buscado não existir
            if(contatoDb == null)
            {
                throw new Exception("Contato inexistente!");
            }

            //Caso o usuário exista, são atribuídos os novos valores
            contatoDb.Nome = contato.Nome; 
            contatoDb.Email = contato.Email; 
            contatoDb.Celular = contato.Celular;

            //Atualizamos e salvamos
            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();

            return contatoDb;
        }
    }
}
