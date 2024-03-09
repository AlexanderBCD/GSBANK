using System.Text;

namespace GSBANK;

class Program
{
    static void Main(string[] args)
    {
        // Configurar la consola para usar UTF-8
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        var menu = new Menu();
        while(true)
        {
            menu.MostrarMenuPrincipa(); //Muestra todas las opciones en consola

            string? input = Console.ReadLine();

            switch(input)
            {
                case "1"://Usuarios Registrados

                break;

                case "2"://Registro de Nuevo Usuario

                break;

                case "3"://Emparejamiento

                break;

                case "4"://Bajas de Usuario

                break;

                case "5"://Salir del Programa

                break;

                default://Otro

                Console.WriteLine("\nRevisar las opciones dispobibles... \nLa opción que eligió es inexistente [ENTER]");
                Console.ReadKey();
            
                break;
            }
        }
        
    }
}
