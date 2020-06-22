using Dapper;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto.Data.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {

        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Aula17;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void Alterar(Perfil obj)
        {
            var query = "update Perfil set Nome = @Nome where IdPerfil = @IdPerfil";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Perfil> Consultar()
        {
            var query = "select * from Perfil";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Perfil>(query).ToList();
            }
        }

        public void Excluir(Perfil obj)
        {
            var query = "delete from Perfil where IdPerfil = @IdPerfil";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Inserir(Perfil obj)
        {
            var query = "insert into Perfil(Nome) values(@Nome)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public Perfil ObterPorId(int id)
        {
            var query = "select * from Perfil where IdPerfil = @IdPerfil";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Perfil>(query, new { IdPerfil = id }).FirstOrDefault();
            }
        }
    }
}
