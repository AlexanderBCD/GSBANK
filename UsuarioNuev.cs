using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace GSBANK
{
    class UsuariosNuev
    {
        private string connectionString = "Server=LAPTOP-R2D2;Database=bancoDeSangre;Integrated Security=True;";

        public void RegistrarNuevoUsuario(string nombres, string apellidoPaterno, string apellidoMaterno, string grupoSanguineo, string rh, string numeroTelefonico)
        {
            string query = "INSERT INTO usuarios (nombres, apellidoPaterno, apellidoMaterno, grupoSanguineo, rh, numeroTelefonico) " +
                           "VALUES (@nombres, @apellidoPaterno, @apellidoMaterno, @grupoSanguineo, @rh, @numeroTelefonico)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                    command.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                    command.Parameters.AddWithValue("@grupoSanguineo", grupoSanguineo);
                    command.Parameters.AddWithValue("@rh", rh);
                    command.Parameters.AddWithValue("@numeroTelefonico", numeroTelefonico);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Usuario registrado exitosamente.");
        }
    }
}

