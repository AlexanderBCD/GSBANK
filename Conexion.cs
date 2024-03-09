using System;
using Microsoft.Data.SqlClient;


namespace GSBANK;

public class ConexionBD
{
    private string connectionString ="Server=LAPTOP-TQH24RE4;Database=????;Integrated Security=True;Encrypt=False;";

    public SqlConnection conexion;

    public ConexionBD()
    {
        conexion = new SqlConnection(connectionString);
    }

    public SqlConnection AbrirConexion()
    {
        try
        {
            conexion.Open();
            Console.WriteLine("Conexion establecida correctamente");
            return conexion;
        }
        catch(FormatException)
        {
            
            Console.WriteLine("Error al extablecer la conexion");
            throw;
        }
    }

    public void CerrarConexion(SqlConnection conexion)
    {
        try
        {
            conexion.Close();
            Console.WriteLine("Conexion cerrada exitosamente");
        }
        catch(FormatException)
        {
            Console.WriteLine("Error al cerrar conexion");
        }
    }
}