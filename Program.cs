using System.Text;

namespace GSBANK;

class Program
{
    static void Main(string[] args)
    {

        // Configurar la consola para usar UTF-8
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        while(true)
        {
            Menu.header();
            Menu.MostrarMenuPrincipa(); //Muestra todas las opciones en consola

            string? input = Console.ReadLine();

            switch(input)
            {
                case "1"://Usuarios Registrados
                    UsuariosRegistrados.MenuUsuarios();
                break;

                case "2"://Registro de Nuevo Usuario
                
                    UsuariosNuev usuariosNuev = new UsuariosNuev();
                    usuariosNuev.RegistrarNuevoUsuario("", "", "", "", "", "");
                break;

                case "3"://Emparejamiento

                    Emparejamiento emp = new Emparejamiento();
                    emp.Compatibles();

                break;

                case "4"://Bajas de Usuario
                    BajasUsuarios.MenuUsuarios();
                break;

                case "5"://Salir del Programa

                return;

                default://Otro

                Console.WriteLine("\nRevisar las opciones dispobibles... \nLa opción que eligió es inexistente [ENTER]");
                Console.ReadKey();
            
                break;
            }
        }
        
    }
}
