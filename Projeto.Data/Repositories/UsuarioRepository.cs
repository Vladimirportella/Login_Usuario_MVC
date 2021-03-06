﻿using Dapper;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Aula17;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Alterar(Usuario obj)
        {
            var query = "update Usuario set Nome = @Nome, Email = @Email, Senha = @Senha, Foto = @Foto, IdPerfil = @IdPerfil where IdUsuario = @IdUsuario";
            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Execute(query, obj);
            }
        }

        public List<Usuario> Consultar()
        {
            var query = "select * from Usuario";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>(query).ToList();
            }
        }

        public Usuario Consultar(string email)
        {
            var query = "select * from Usuario where Email = @Email ";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>(query, new { Email = email }).FirstOrDefault();
            }
        }

        public Usuario Consultar(string email, string senha)
        {
            var query = "select * from Usuario where Email = @Email and Senha = @Senha ";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>(query, new { Email = email, Senha = senha }).FirstOrDefault();
            }
        }

        public List<Usuario> Consultar(int idPerfil)
        {
            var query = "select * from Usuario where IdPerfil = @IdPerfil";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>(query, new { IdPerfil = idPerfil }).ToList();
            }
        }

        public void Excluir(Usuario obj)
        {
            var query = "delete from Usuario where IdUsuario = @IdUsuario";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Inserir(Usuario obj)
        {
            var query = "insert into Usuario(Nome, Email, Senha, Foto, DataCriacao, IdPerfil) values(@Nome, @Email, @Senha, @Foto, @DataCriacao, @IdPerfil)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public Usuario ObterPorId(int id)
        {
            var query = "select * from Perfil where IdUsuario = @IdUsuario";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Usuario>(query, new { IdUsuario = id }).FirstOrDefault();
            }
        }
    }
}
