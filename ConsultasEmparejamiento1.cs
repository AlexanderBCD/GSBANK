using System;
using Microsoft.Data.SqlClient;

namespace GSBANK;

class HelperEmparejamiento{

    string connectionString = "Server=LAPTOP-TQH24RE4;Database=bancoDeSangre;Integrated Security=True;Encrypt=False;";

    public string[]? ConsultarId(string? input, string? input2, string? input3)
    {
        string query ="SELECT grupoSanguineo,rh FROM usuarios WHERE nombres = @input AND apellidoPaterno = @input2 AND apellidoMaterno = @input3";
    
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query,connection))
            {
                command.Parameters.AddWithValue("@input",input);
                command.Parameters.AddWithValue("@input2",input2);
                command.Parameters.AddWithValue("@input3",input3);
                connection.Open();

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string TipodeSangre =reader.GetString(0);
                        string Rh = reader.GetString(1);

                        return new string[] {TipodeSangre,Rh};
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    
    }

    public void PersonasCompatibles(string port1, string port2, string? input, string? input2)
    {
        string query;

        if(port1 == "A" && port2 =="+")
        {
            query = "SELECT * FROM usuarios WHERE grupoSanguineo IN ('O','A') ";
            
        }
        else if(port1 == "AB")
        {
            query ="SELECT * FROM usuarios WHERE nombres !=@input AND apellidoPaterno !=@input2";
        }
        else if(port1 == "A" && port2 =="-")
        {
            query = "SELECT * FROM usuarios WHERE grupoSanguineo IN ('O','A') AND rh=@port2 ";

        }
        else
        {
            query ="Nothing";
        }

        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query,connection))
            {
                command.Parameters.AddWithValue("@input",input);
                command.Parameters.AddWithValue("@input2",input2);
                command.Parameters.AddWithValue("@port2",port2);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}  NOMBRE: {reader["nombres"]}  {reader["apellidoPaterno"]}  {reader["apellidoMaterno"]}");
                    }

                    Console.ReadKey();
                }
            }
        }
    }
}