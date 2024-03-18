using CrudMVC.Enums;
using CrudMVC.Helper;
using System.ComponentModel.DataAnnotations;

namespace CrudMVC.Models
{
    public class UsuarioModel
    {
        /*
         * Utilizamos o DataAnnotations para validar os campos no HTMl
         * 
         * -- Required: menciona que o campo é obrigatório
         * -- EmailAddress: menciona se o email informado é válido
        */
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite o email do usuário")]
        [EmailAddress(ErrorMessage = "O email informado é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            //atribuímos a senha criptografada
            return Senha == senha.GerarHash();
        }

        //Criamos o método para transformar a senha informada em uma senha criptografada
        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        //Criamos o método para setar uma nova senha e geramos o hash
        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }
    }
}
