using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace GSBANK
{
    class UsuariosNuev
    {
        string connectionString = "Server=LAPTOP-TQH24RE4;Database=bancoDeSangre;Integrated Security=True;Encrypt=False;";

       public void ConectarABaseDeDatos()
        {

            string query =""; //CADENA DE CONSULTA DEPENDE LO QUE NECESITES HACER


           using (SqlConnection connection = new SqlConnection(connectionString))
           {

              using (SqlCommand command = new SqlCommand(query,connection))
              {
                    //LOGICA DE PROGRAMACION
              }
           }

           
        }
  }
}

