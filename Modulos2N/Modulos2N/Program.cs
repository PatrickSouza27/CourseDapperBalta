using System;
using Microsoft.Data.SqlClient;
using Modulos2N.Models;
using Dapper;
namespace Modulo2N
{
    class Program
    {

        static void Main(string[] args)
        {
            Curso x = new Curso();
            Console.WriteLine("Digite o nome do curso:");
            x.Nome = Console.ReadLine();
            Console.WriteLine("Digite a categoria:");
            x.CategoriaId = int.Parse(Console.ReadLine());
            const string connectionString = "Server=localhost, 1433;Database=Cursos;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

            using (var connection = new SqlConnection(connectionString))
            {

                var insertsql = $@"INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES (@batata, @arroz)";

                connection.Execute(insertsql, new { batata = x.Nome, arroz = x.CategoriaId });
  
                var cursos = connection.Query<Curso>("SELECT * FROM curso");
                foreach(var curso in cursos)
                {
                    Console.WriteLine(curso);
                }
            }
        }
    }
}