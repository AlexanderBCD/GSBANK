using Microsoft.Data.SqlClient;

namespace GSBANK
{
    class UsuariosNuevos
    {
        private ConexionBD conexionBD;

        public UsuariosNuevos(ConexionBD conexionBD)
        {
            this.conexionBD = conexionBD;
        }

        public void RegistrarNuevoUsuario(Usuario usuario)
        {
            string query = "INSERT INTO usuarios (nombres, apellidoPaterno, apellidoMaterno, grupoSanguineo, rh, numeroTelefonico) " +
                           "VALUES (@nombres, @apellidoPaterno, @apellidoMaterno, @grupoSanguineo, @rh, @numeroTelefonico)";
            using (SqlConnection connection = conexionBD.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombres", usuario.Nombres);
                    command.Parameters.AddWithValue("@apellidoPaterno", usuario.ApellidoPaterno);
                    command.Parameters.AddWithValue("@apellidoMaterno", usuario.ApellidoMaterno);
                    command.Parameters.AddWithValue("@grupoSanguineo", usuario.GrupoSanguineo);
                    command.Parameters.AddWithValue("@rh", usuario.Rh);
                    command.Parameters.AddWithValue("@numeroTelefonico", usuario.NumeroTelefonico);

                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Usuario registrado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                    }
                }
            }
        }
    }
}