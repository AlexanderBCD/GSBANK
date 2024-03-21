using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace GSBANK;

class UsuariosRegistrados
{
    public static void MenuUsuarios()
    {
        while (true)
        {
            Menu.header();
            Console.WriteLine("🩸 Bienvenido al Sistema de Búsqueda del Banco de Sangre 🩸");
            Console.WriteLine("\nSelecciona cómo deseas buscar a los usuarios registrados:\n");
            Console.WriteLine("1️⃣  Por Nombre");
            Console.WriteLine("2️⃣  Por Apellido Paterno");
            Console.WriteLine("3️⃣  Por Apellido Materno");
            Console.WriteLine("4️⃣  Por Nombre Completo");
            Console.WriteLine("5️⃣  Por Teléfono");
            Console.WriteLine("6️⃣  Por Tipo De Sangre");
            Console.WriteLine("7️⃣  Salir");
            Console.WriteLine("\nPor favor, ingresa el número de la opción deseada...");
            Console.Write("\n-- 👉: ");

            string? criterioDeBusqueda = Console.ReadLine();
            string? valorDeBusqueda = "";
            bool condition = false;
            Menu.header();
            switch (criterioDeBusqueda)
            {
                
                case "1": //Por Nombre
                    Console.WriteLine("Por favor ingrese ambos nombres del usuario a buscar...");
                    Console.Write("\n-- 👉: ");
                    valorDeBusqueda = Console.ReadLine();
                    criterioDeBusqueda = "nombres";
                    condition = true;
                    break;
                case "2": //Por Apellido Paterno
                    Console.WriteLine("Por favor ingrese solo el apellido paterno del usuario a buscar...");
                    Console.Write("\n-- 👉: ");
                    valorDeBusqueda = Console.ReadLine();
                    criterioDeBusqueda = "apellidoPaterno";
                    condition = true;
                    break;
                case "3": //Por Apellido Materno
                    Console.WriteLine("Por favor ingrese solo el apellido materno del usuario a buscar...");
                    Console.Write("\n-- 👉: ");
                    valorDeBusqueda = Console.ReadLine();
                    criterioDeBusqueda = "apellidoMaterno";
                    condition = true;
                    break;
                case "4": //Por Nombre Completo
                    Console.WriteLine("Por favor ingrese el nombre completo (Con acentos) del usuario a buscar...");
                    Console.Write("\n-- 👉: ");
                    valorDeBusqueda = Console.ReadLine();
                    criterioDeBusqueda = "nombreCompleto";
                    condition = true;
                    break;
                case "5": //Por Teléfono
                    Console.WriteLine("Por favor ingrese el numero telefónico del usuario a buscar...");
                    Console.Write("\n-- 👉: ");
                    valorDeBusqueda = Console.ReadLine();
                    criterioDeBusqueda = "numeroTelefonico";
                    condition = true;
                    break;
                case "6": //Por Grupo Sanguíneo
                    Console.WriteLine("Por favor ingrese el tipo de sangre (Ejemplo AB+) del usuario a buscar...");
                    Console.Write("\n-- 👉: ");
                    valorDeBusqueda = Console.ReadLine();
                    criterioDeBusqueda = "grupoSanguineo";
                    condition = true;
                    break;

                case "7": //Por Grupo Sanguíneo
                    Console.WriteLine("Volviendo al menú... [ENTER]");
                    Console.ReadKey();
                    return;
                default:
                    Console.WriteLine("❌ Opción no válida. Por favor, intenta de nuevo... [ENTER]");
                    Console.ReadKey();
                    break;

            }
            if (condition == true)
            { 
                RealizarBusqueda(criterioDeBusqueda, valorDeBusqueda);   
            }
        }
        
    }

    static void RealizarBusqueda(string? criterio, string? valorDeBusqueda)
    {
        ConexionBD conexionBD = new ConexionBD();
        try
        {
            string Query = $"SELECT * FROM usuarios WHERE {ConstruirCriterioSQL(criterio, valorDeBusqueda)}";
            var cmd = new SqlCommand(Query, conexionBD.AbrirConexion());

            using SqlDataReader lector = cmd.ExecuteReader();
            if (lector.HasRows)
            {
                Menu.header();
                Console.WriteLine($"\nNombre completo \t\t\tNúmero de teléfono \tGrupo Sanguíneo y RH\n");
                while (lector.Read())
                {
                    Console.WriteLine($"{lector["nombres"]} {lector["apellidoPaterno"]} {lector["apellidoMaterno"]} \t {lector["numeroTelefonico"]}\t\t{lector["grupoSanguineo"]}{lector["rh"]} ");
                }
            }
            else
            {
                Console.WriteLine($"\nNo Se han encontrado resultados... [ENTER]");
                
            }
            Console.WriteLine($"\n[ENTER]");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.ReadKey();
        }
        finally
        {
            conexionBD.CerrarConexion();
        }

        
    }

    static string ConstruirCriterioSQL(string? criterio, string? valorDeBusqueda)
    {
        switch (criterio)
        {
            case "nombreCompleto":
                return DescomponerNombre(valorDeBusqueda);

            case "grupoSanguineo":
                return DescomponerTipoDeSangre(valorDeBusqueda);

            case "numeroTelefonico":
                return $"{criterio} = {valorDeBusqueda}";

            default:
                return $"{criterio} = '{valorDeBusqueda}'";
        }
    }


    public static string DescomponerNombre(string? nombreCompleto)
    {
        // Expresión regular que captura los nombres y apellidos
        var regex = new Regex(@"^(?<nombres>.+)\s(?<apellidoPaterno>\S+)\s(?<apellidoMaterno>\S+)$");
        #pragma warning disable CS8604 // Posible argumento de referencia nulo
        var match = regex.Match(nombreCompleto);
        #pragma warning restore CS8604 // Posible argumento de referencia nulo
        var nombres = match.Groups["nombres"].Value.Trim();
        var apellidoPaterno = match.Groups["apellidoPaterno"].Value.Trim();
        var apellidoMaterno = match.Groups["apellidoMaterno"].Value.Trim();

        return $"nombres = '{nombres}' and apellidoPaterno = '{apellidoPaterno}' and apellidoMaterno = '{apellidoMaterno}'";
    }

    static string DescomponerTipoDeSangre(string? tipoDeSangre)
    {
        // Expresión regular para capturar grupo sanguíneo y factor Rh
        var regex = new Regex(@"^(?<grupoSanguineo>A|B|AB|O)(?<rh>\+|\-)$");
        #pragma warning disable CS8604 // Posible argumento de referencia nulo
        var match = regex.Match(tipoDeSangre);
        #pragma warning restore CS8604 // Posible argumento de referencia nulo

        var grupoSanguineo = match.Groups["grupoSanguineo"].Value;
        var rh = match.Groups["rh"].Value;

        return $"grupoSanguineo = '{grupoSanguineo}' and rh = '{rh}'";
    }
}