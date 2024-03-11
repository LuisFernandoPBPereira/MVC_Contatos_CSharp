﻿using CrudMVC.Models;

namespace CrudMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel BuscarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Editar(ContatoModel contato);
        bool Apagar(int id);
    }
}