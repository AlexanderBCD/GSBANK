using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace GSBANK;

class UsuariosRegistrados
{
    public static void MenuUsuarios()
    {
        Console.Clear();
        Console.WriteLine("🩸 Bienvenido al Sistema de Búsqueda del Banco de Sangre 🩸");
        Console.WriteLine("\nSelecciona cómo deseas buscar a los usuarios registrados:\n");
        Console.WriteLine("1️⃣  Por Nombre");
        Console.WriteLine("2️⃣  Por Apellido Paterno");
        Console.WriteLine("3️⃣  Por Apellido Materno");
        Console.WriteLine("4️⃣  Por Nombre Completo");
        Console.WriteLine("5️⃣  Por Teléfono");
        Console.WriteLine("6️⃣  Por Grupo Sanguíneo");
        Console.WriteLine("7️⃣  Salir");
        Console.WriteLine("\nPor favor, ingresa el número de la opción deseada...");
        Console.Write("\n-- 👉: ");

        string? criterioDeBusqueda = Console.ReadLine();
        string? valorDeBusqueda;
        Console.Clear();
        switch (criterioDeBusqueda)
        {
            
            case "1": //Por Nombre
                Console.WriteLine("Por favor ingrese ambos nombres del usuario a buscar...");
                Console.Write("\n-- 👉: ");
                valorDeBusqueda = Console.ReadLine();
                criterioDeBusqueda = "nombres";
                break;
            case "2": //Por Apellido Paterno
                Console.WriteLine("Por favor ingrese solo el apellido paterno del usuario a buscar...");
                Console.Write("\n-- 👉: ");
                valorDeBusqueda = Console.ReadLine();
                criterioDeBusqueda = "apellidoPaterno";
                break;
            case "3": //Por Apellido Materno
                Console.WriteLine("Por favor ingrese solo el apellido materno del usuario a buscar...");
                Console.Write("\n-- 👉: ");
                valorDeBusqueda = Console.ReadLine();
                criterioDeBusqueda = "apellidoMaterno";
                break;
            case "4": //Por Nombre Completo
                Console.WriteLine("Por favor ingrese el nombre completo (Con acentos) del usuario a buscar...");
                Console.Write("\n-- 👉: ");
                valorDeBusqueda = Console.ReadLine();
                criterioDeBusqueda = "nombreCompleto";
                break;
            case "5": //Por Teléfono
                Console.WriteLine("Por favor ingrese el numero telefonico del usuario a buscar...");
                Console.Write("\n-- 👉: ");
                valorDeBusqueda = Console.ReadLine();
                criterioDeBusqueda = "numeroTelefonico";
                break;
            case "6": //Por Grupo Sanguíneo
                Console.WriteLine("Por favor ingrese grupo sanguineo del usuario a buscar...");
                Console.Write("\n-- 👉: ");
                valorDeBusqueda = Console.ReadLine();
                criterioDeBusqueda = "grupoSanguineo";
                break;
            default:
                Console.WriteLine("❌ Opción no válida. Por favor, intenta de nuevo.");
                return;
        }

        RealizarBusqueda(criterioDeBusqueda, valorDeBusqueda);
    }

    static void RealizarBusqueda(string criterio, string? valorDeBusqueda)
    {
        ConexionBD conexionBD = new ConexionBD();
        try
        {
            string Query = $"SELECT * FROM usuarios WHERE {ConstruirCriterioSQL(criterio, valorDeBusqueda)}";
            var cmd = new SqlCommand(Query, conexionBD.AbrirConexion());

            using SqlDataReader lector = cmd.ExecuteReader();
            if (lector.HasRows)
            {
                Console.Clear();
                Console.WriteLine($"\nNombre competo \t\t\tNumero de telefono \tGrupo Sanguineo y RH\n");
                while (lector.Read())
                {
                    Console.WriteLine($"{lector["nombres"]} {lector["apellidoPaterno"]} {lector["apellidoMaterno"]} \t {lector["numeroTelefonico"]}\t\t{lector["grupoSanguineo"]}{lector["rh"]} ");
                }
            }
            else
            {
                Console.WriteLine($"\nNo Se han encontrado resultados.");
                
            }
            Console.WriteLine($"\nENTER\n");
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

    static string ConstruirCriterioSQL(string criterio, string? valorDeBusqueda)
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


    static string DescomponerNombre(string? nombreCompleto)
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