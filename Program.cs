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
            menu.MostrarMenuPrincipa();

            string? input = Console.ReadLine();

            switch(input)
            {
                case "1":

                break;

                case "2":

                break;

                case "3":

                break;

                case "4":

                break;

                case "5":

                break;

                default:

                Console.WriteLine("\nRevisar las opciones dispobibles... \nLa opción que eligió es inexistente [ENTER]");
                Console.ReadKey();
            
                break;
            }
        }
        
    }
}
