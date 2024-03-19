using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;


namespace GSBANK;

class BajasUsuarios
{
    public static void MenuUsuarios()
    {
        while (true)
        {
            Menu.header();
            Console.WriteLine("\n🚫 Menú de bajas de usuario 🚫\n");
            Console.WriteLine("1️⃣  Dar de baja un usuario");
            Console.WriteLine("2️⃣  Ver usuarios dados de baja");
            Console.WriteLine("3️⃣  Volver a activar un usuario dado de baja");
            Console.WriteLine("4️⃣  Salir");
            Console.WriteLine("\nPor favor, ingresa el número de la opción deseada...");
            Console.Write("\n-- 👉: ");
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                DarDeBajaU();
                break;

                case "2":
                VerUsuariosBaja();
                break;

                case "3":
                break;

                case "4":
                break;

                default:
                break;
            }
        }
    }
    public static void  VerUsuariosBaja()
    {
        Menu.header();
        Console.WriteLine("🩸Usuarios dados de baja🩸\n");
        ConexionBD conexionBD = new ConexionBD();
        try
        {
            string Query5 = "SELECT * FROM UsuariosBajas";
            var cmd5 = new SqlCommand(Query5, conexionBD.AbrirConexion());

            using SqlDataReader lector = cmd5.ExecuteReader();
            if (lector.HasRows)
            {
                
                Console.WriteLine($"\nNombre completo \t\t\tNumero de telefono \tGrupo Sanguineo y RH\t Motivo de baja\n");
                while (lector.Read())
                {
                    Console.WriteLine($"{lector["nombres"]} {lector["apellidoPaterno"]} {lector["apellidoMaterno"]} \t {lector["numeroTelefonico"]}\t\t{lector["grupoSanguineo"]}{lector["rh"]}\t\t{lector["motivo"]}");
    
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            conexionBD.CerrarConexion();
        }
        Console.WriteLine($"\n[ENTER]");
        Console.ReadKey();

    }
    public static void  DarDeBajaU()
    {
        while (true)
        {
            Menu.header();
            Console.WriteLine("Por favor ingrese el nombre completo del usuario a eliminar [* Para salir.]... \n[Si el nombre lleva acentos, por favor colocarlos.]");
            Console.Write("\n-- 👉: ");
            string?  valorDeBusqueda = Console.ReadLine();
            if (valorDeBusqueda == "*")
            {
                return;
            }

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                string Query = $"SELECT * FROM usuarios WHERE {UsuariosRegistrados.DescomponerNombre(valorDeBusqueda)}";
                var cmd = new SqlCommand(Query, conexionBD.AbrirConexion());

                using SqlDataReader lector = cmd.ExecuteReader();
                if (lector.HasRows)
                {
                    
                    Menu.header();
                    Console.WriteLine($"\nNombre competo \t\t\tNumero de telefono \tGrupo Sanguineo y RH\n");
                    lector.Read();
                    Console.WriteLine($"{lector["nombres"]} {lector["apellidoPaterno"]} {lector["apellidoMaterno"]} \t {lector["numeroTelefonico"]}\t\t{lector["grupoSanguineo"]}{lector["rh"]} ");
                    string? id = lector["id"].ToString();
                    string? nombres = lector["nombres"].ToString();
                    string? apellidoPaterno = lector["apellidoPaterno"].ToString();
                    string? apellidoMaterno = lector["apellidoMaterno"].ToString();
                    string? numeroTelefonico = lector["numeroTelefonico"].ToString();
                    string? direccion = lector["direccion"].ToString();
                    string? grupoSanguineo = lector["grupoSanguineo"].ToString();
                    string? rh = lector["rh"].ToString();


                    conexionBD.CerrarConexion();


                    Console.WriteLine("\nPor favor ingrese el motivo por la cual se da de baja este usuario. [* PARA CANCELAR]");
                    Console.Write("\n-- 👉: ");
                    string? motivo;
                    while (true)
                    {
                        motivo = Console.ReadLine();
                        if (motivo == "*" )
                        {
                            Console.WriteLine("Ha cancelado la operación. [ENTER]");
                            Console.ReadKey();
                            return;
                        }
                        else if (motivo == null || !motivo.Any())
                        {
                            Console.WriteLine("Es obligatorio un motivo.");
                            Console.Write("\n-- 👉: ");
                        }
                        else{break;}
                    }

                    Menu.header();
                    Console.WriteLine($"\nNombre competo \t\t\tNumero de telefono \tGrupo Sanguineo y RH\t Motivo de baja\n");
                    Console.WriteLine($"{nombres} {apellidoPaterno} {apellidoMaterno} \t {numeroTelefonico}\t\t{grupoSanguineo}{rh}\t\t{motivo}");
                    Console.WriteLine("\n1️⃣  Confirmar y dar de baja");
                    Console.WriteLine("2️⃣  Cancelar");
                    Console.Write("\n-- 👉: ");
                    while (true)
                    {
                        string? input = Console.ReadLine();
                        if (input == "2" )
                        {
                            Console.WriteLine("Ha cancelado la operación. [ENTER]");
                            Console.ReadKey();
                            return;
                        }
                        else if (input != "1")
                        {
                            Console.WriteLine("Ingrese una opción.");
                            Console.Write("\n-- 👉: ");
                        }
                        else{break;}
                    }

                    try// Eliminar de la tabla principal
                    {
                        string Query2 = $"DELETE FROM usuarios WHERE id = {id}";
                        var cmd2 = new SqlCommand(Query2, conexionBD.AbrirConexion());
                        cmd2.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    finally
                    {
                        conexionBD.CerrarConexion();
                    }

                    // Meter a la segunda tabla
                    try
                    {
                        string Query3 = $"INSERT INTO UsuariosBajas (nombres,apellidoPaterno,apellidoMaterno,numeroTelefonico,direccion,grupoSanguineo,rh,motivo) VALUES ('{nombres}','{apellidoPaterno}','{apellidoMaterno}','{numeroTelefonico}','{direccion}','{grupoSanguineo}','{rh}','{motivo}')";
                        var cmd3 = new SqlCommand(Query3, conexionBD.AbrirConexion());
                        cmd3.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    finally
                    {
                        conexionBD.CerrarConexion();
                    }

                    Console.WriteLine($"Se ha dado de baja al usuario: {nombres} {apellidoPaterno} {apellidoMaterno}\n[ENTER]");
                    Console.ReadKey();
                    return;


                }
                else
                {
                    Console.WriteLine($"\nNo existe un usuario registrado con el nombre ingresado... [ENTER]");
                    
                }
                Console.WriteLine($"\n[ENTER]");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadKey();
            }
            /*finally
            {
                conexionBD.CerrarConexion();
            }*/


        }
    }
}