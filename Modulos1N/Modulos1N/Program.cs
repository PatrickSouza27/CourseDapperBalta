using Microsoft.Data.SqlClient;
namespace Modulo1
{
    class Program {
        
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost, 1433;Database=Cursos;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
            using(var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("conectado");
                connection.Open();
                using (var command = new SqlCommand()) {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [ID], [Nome], [CategoriaId] FROM [Curso]";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)} - {reader.GetString(1)} - {reader.GetInt32(2)}");
                    }
                }
            }
        }
    }
}
