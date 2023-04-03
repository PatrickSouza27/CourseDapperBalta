using System;
using System.Data;
using System.Threading.Channels;
using Dapper;
using Microsoft.Data.SqlClient;
using Modulos4N.Entities;

/*PROCEDURE: CREATE OR ALTER PROCEDURE Deletar @Id INT AS
    DELETE [Categoria]
    WHERE [Id] = @Id;*/

namespace Modulo4
{
    class Program
    {
        static readonly string connectionString = "Server=localhost, 1433;Database=Dapper;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        static int AdicionarCategorias(SqlConnection conectar)
        {
            var categoria1 = new Categoria(1, "Azure");
            var categoria2 = new Categoria(1, "Oracle");

            return conectar.Execute("INSERT INTO [Categoria]([Name]) VALUES (@Name)", new[]
            {
                new {categoria1.Name },
                new {categoria2.Name }
            });

        }
        static void Listar(SqlConnection conectar)
        {
            string query = "SELECT * FROM [Categoria] ORDER BY [Id];";
            var lista = conectar.Query<Categoria>(query);
            foreach(var listar in lista)
            {
                Console.WriteLine(listar);
            }
        }

        static void ExecuteProcedure(SqlConnection conectar)
        {
            string Query = "Deletar";
            var parametro = new { Id = 14 };
            conectar.Execute(Query, parametro, commandType: CommandType.StoredProcedure);
        }
        static void ExecuteReadProcedure(SqlConnection conectar)
        {
            string Query = "MostrarCategoria";
            var parametro = new { Cat = "front-end" };
            var courses = conectar.Query(Query, parametro, commandType: CommandType.StoredProcedure);
            foreach(var es in courses)
            {
                Console.WriteLine(es.Name);
            }
           
        }
        static void OneToOne(SqlConnection conectar)
        {
            string sql = @"SELECT * FROM [Curso]
            INNER JOIN 
                [Categoria] 
                    ON [Curso].[FK_Categoria] = [Categoria].[Id]; ";
            List<Curso> item = new List<Curso>(conectar.Query<Curso, Categoria, Curso>(sql, (curso, categoria) =>
            {
                curso.FK_CategoriaObj = categoria;
                return curso;
            }));
            item.ForEach(x =>
            {
                Console.WriteLine(x.FK_CategoriaObj.Id);
            });
        }
        static void Main()
        {

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                //AdicionarCategorias(connection);
                //ExecuteProcedure(connection);
                //Listar(connection);
                //ExecuteReadProcedure(connection);
                OneToOne(connection);
            }
        }
    }
}
