﻿using CrudMVC.Data.Map;
using CrudMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMVC.Data
{
    public class BancoContext : DbContext
    {
        //Construtor do contexto do banco, passando as opções de contexto no parâmetro
        //Em base(options), é retornada options para DbContext
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        //Esta será a tabela do banco de dados, passando um Set no banco de dados
        //Esse Set é do tipo ContatoModel, que possui os campos: Id, Nome, Email e Celular
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
