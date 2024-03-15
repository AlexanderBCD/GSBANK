using System;
using Microsoft.Data.SqlClient;

namespace GSBANK;

class HelperEmparejamiento{

    string connectionString = "Server=LAPTOP-TQH24RE4;Database=bancoDeSangre;Integrated Security=True;Encrypt=False;";

    public string[]? ConsultarId(int id)
    {
        string query ="SELECT nombres,apellidoPaterno,apellidoMaterno FROM usuarios WHERE id = @id";
    
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query,connection))
            {
                command.Parameters.AddWithValue("@id",id);
                connection.Open();

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nombres =reader.GetString(0);
                        string apellidoPaterno = reader.GetString(1);
                        string apellidoMaterno = reader.GetString(2);

                        return new string[] {nombres, apellidoPaterno, apellidoMaterno};
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    
    }
}