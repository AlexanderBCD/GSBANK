namespace GSBANK
{
    class RegistrarNuevoUsuario
    {   
        public static Usuario ObtenerDatos()
        {
            string nombre = "";
            string apellidoPaterno = "";
            string apellidoMaterno = "";
            string grupoSanguineo = "";
            string rh = "";
            string numeroTelefonico = "";

            Console.WriteLine("Por favor introducir los datos del paciente conforme se solicite");
            
            Console.WriteLine("Nombre:");
            nombre = Console.ReadLine() ?? string.Empty;
            
            Console.WriteLine("Apellido paterno:");
            apellidoPaterno = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Apellido materno:");
            apellidoMaterno = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Su grupo sanguíneo: ");
            grupoSanguineo = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("RH: ");
            rh = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Numero de telefono: ");
            numeroTelefonico = Console.ReadLine() ?? string.Empty;

            return new Usuario
            {
                Nombres = nombre,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                GrupoSanguineo = grupoSanguineo,
                Rh = rh,
                NumeroTelefonico = numeroTelefonico
            };
        }
    }
}
