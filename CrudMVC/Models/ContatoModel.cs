﻿using System.ComponentModel.DataAnnotations;

namespace CrudMVC.Models;

/*
    Model para auxiliar na criação da tabela do banco de dados
    através de uma migration
 */
public class ContatoModel
{
    /*
     * Utilizamos o DataAnnotations para validar os campos no HTMl
     * 
     * -- Required: menciona que o campo é obrigatório
     * -- EmailAddress: menciona se o email informado é válido
    */
    public int Id { get; set; }
    [Required(ErrorMessage = "Digite o nome do contato")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Digita o email do contato")]
    [EmailAddress(ErrorMessage = "O email informado não é válido!")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Digite o celular do contato")]
    [Phone(ErrorMessage = "O celular informado não é válido")]
    public string Celular { get; set; }
    public int? UsuarioId { get; set; }
    public UsuarioModel? Usuario { get; set; }
}
