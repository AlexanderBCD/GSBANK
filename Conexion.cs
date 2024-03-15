using Microsoft.Data.SqlClient;

namespace GSBANK;

public class ConexionBD
{
    //Conexion RafaPC [NO BORRAR]
    //private string connectionString ="Server=DESKTOP-KEI8B51;Database=bancoDeSangre;Integrated Security=True;";
    
    //Conexion RafaLAP [NO BORRAR]
    //private string connectionString ="Server=DESKTOP-3EG8250;Database=bancoDeSangre;Integrated Security=True;";
    
    //Conexion Bolio [BORRAR por favor :v]
    private string connectionString ="Server=LAPTOP-TQH24RE4;Database=bancoDeSangre;Integrated Security=True;Encrpyt=False;";

    //Conxion Arturo [BORRALO]
    //private string connectionString ="Server=LAPTOP-R2D2;Database=bancoDeSangre;Integrated Security=True;";

    public SqlConnection conexion;

    public ConexionBD()
    {
        conexion = new SqlConnection(connectionString);
    }

    public SqlConnection? AbrirConexion()
    {
        try
        {
            conexion.Open();
            return conexion;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al abrir la conexión: {ex.Message}");
            return null;
        }
    }

    public void CerrarConexion()
    {
        conexion.Close();
    }

    
}