using System;
using System.Text.RegularExpressions;

namespace GSBANK
{
    class GestorUsuario
    {
        public static Usuario ObtenerDatosUsuario() 
        {
            string nombre = "";
            string apellidoPaterno = "";
            string apellidoMaterno = "";
            string grupoSanguineo = "";
            string rh = "";
            string numeroTelefonico = "";
            string direccion = "";

            Console.WriteLine("Por favor introducir los datos del paciente conforme se solicite");

          while (true)
            {
                Console.WriteLine("Nombres o Nombre:");
                nombre = Console.ReadLine()?.Trim() ?? string.Empty;

                if (nombre.Split(' ').Length >= 2)
                {
                    break; 
                }
                Console.WriteLine("Por favor ingrese al menos dos nombres separados por un espacio.");
            }

            while (true)
            {
                Console.WriteLine("Apellido paterno:");
                apellidoPaterno = Console.ReadLine() ?? string.Empty;
                if (EsApellidoValido(apellidoPaterno))
                {
                    break; 
                }
                Console.WriteLine("Apellido paterno no válido. Inténtalo de nuevo.");
            }

            while (true)
            {
                Console.WriteLine("Apellido materno:");
                apellidoMaterno = Console.ReadLine() ?? string.Empty;
                if (EsApellidoValido(apellidoMaterno))
                {
                    break; 
                }
                Console.WriteLine("Apellido materno no válido. Inténtalo de nuevo.");
            }

            while (true)
            {
                Console.WriteLine("Su grupo sanguíneo (A, O, B, AB): ");
                grupoSanguineo = Console.ReadLine()?.Trim().ToUpper() ?? string.Empty;
                if (EsGrupoSanguineoValido(grupoSanguineo))
                {
                    break; 
                }
                Console.WriteLine("Grupo sanguíneo no válido. Inténtalo de nuevo.");
            }

            while (true)
            {
                Console.WriteLine("RH (Positivo(+) o Negativo(-)): ");
                rh = Console.ReadLine()?.Trim().ToUpper() ?? string.Empty;
                if (EsRHValido(rh))
                {
                    break; 
                }
                Console.WriteLine("RH no válido. Inténtalo de nuevo.");
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Numero de telefono(10 digitos): ");
                    numeroTelefonico = Console.ReadLine();
                    long.Parse(numeroTelefonico); 
                    break; 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Número de teléfono no válido. Inténtalo de nuevo.");
                }
            }

            Console.WriteLine("Direccion: ");
            direccion = Console.ReadLine() ?? string.Empty;

            return new Usuario
            {
                Nombres = nombre,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                GrupoSanguineo = grupoSanguineo,
                Rh = rh,
                NumeroTelefonico = numeroTelefonico,
                Direccion = direccion
            };
        }

        private static bool EsNombreValido(string texto)
        {
            return !Regex.IsMatch(texto, @"[\d\W]");
        }

        private static bool EsApellidoValido(string texto)
        {
            return !Regex.IsMatch(texto, @"[\d\W]");
        }

        private static bool EsGrupoSanguineoValido(string grupoSanguineo)
        {
            return Regex.IsMatch(grupoSanguineo, @"^[AOB]+$|^AB$");
        }

        private static bool EsRHValido(string rh)
        {
            return rh == "+" || rh == "-";
        }
    }
}
