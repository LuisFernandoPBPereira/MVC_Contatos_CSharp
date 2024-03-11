using CrudMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace CrudMVC.Models
{
    public class UsuarioSemSenhaModel
    {
        /*
         * Houve a necessidade de criar outra Model para usuário,
         * com a diferença de que não há o atributo Senha, pois nesta
         * regra de negócio, não alteramos a senha.
         * 
         * Utilizamos o DataAnnotations para validar os campos no HTML
         * 
         * -- Required: menciona que o campo é obrigatório
         * -- EmailAddress: menciona se o email informado é válido
        */
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email do usuário")]
        [EmailAddress(ErrorMessage = "O email informado é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
    }
}
