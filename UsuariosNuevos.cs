using Microsoft.Data.SqlClient;
using System;

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
            string query = "INSERT INTO usuarios (nombres, apellidoPaterno, apellidoMaterno, grupoSanguineo, rh, numeroTelefonico, direccion) " +
                           "VALUES (@nombres, @apellidoPaterno, @apellidoMaterno, @grupoSanguineo, @rh, @numeroTelefonico, @direccion)";
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
                    command.Parameters.AddWithValue("@direccion", usuario.Direccion);

                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Usuario registrado exitosamente.");

                        Console.WriteLine("¿Desea registrar otro usuario? (Sí/No)");
                        string respuesta = Console.ReadLine()?.Trim().ToUpper() ?? "";
                    if (respuesta == "SI" || respuesta == "SÍ")
                        {
                            Console.Clear();
                            UsuariosNuevos usuariosNuevos = new UsuariosNuevos(new ConexionBD());
                            Usuario nuevoUsuario = GestorUsuario.ObtenerDatosUsuario();
                            usuariosNuevos.RegistrarNuevoUsuario(nuevoUsuario); 
                        }
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
