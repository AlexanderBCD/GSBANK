using System.Data.SqlClient;

namespace GSBANK
{
    class UsuariosNuev
    {
        private ConexionBD conexionBD;

        public UsuariosNuev()
        {
            conexionBD = new ConexionBD();
        }

       // public void ConectarABaseDeDatos()
       // {
       //     using (SqlConnection connection = conexionBD.AbrirConexion())
       //     {
       //         // COMO COÑO ME COECTO A LA BASE DE DATOOOOS PARA REALIZAR MIS PROCESOS AAAAAAA
       //     }
       // }
    }
}

