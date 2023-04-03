using System;
using Modulos2N.Models;
using Dapper;
using System.Data.SqlClient;

namespace Modulo2N
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do curso:");
            string nomecurso = Console.ReadLine();
            Console.WriteLine("Digite a categoria:");
            int categoriaId = int.Parse(Console.ReadLine());

            const string connectionString = "Server=localhost, 1433;Database=Cursos;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

            using (var connection = new SqlConnection(connectionString))
            {

                var insertsql = @"INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES (@Nome, @CategoriaId)";

                var qtd = connection.Execute(insertsql, new {Nome = nomecurso, CategoriaId = categoriaId });
                Console.WriteLine($"{qtd} linhas inseridas");

                var cursos = connection.Query<Curso>("SELECT [Curso].[ID], [Curso].[Nome], [Categoria].[Nome] AS [NomeCategoria] FROM [Curso] INNER JOIN [Categoria] ON [Curso].[CategoriaId] = [Categoria].[ID];");
                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso);
                }
            }
        }
    }
}