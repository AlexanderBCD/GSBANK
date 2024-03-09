using System.Text;

namespace GSBANK;

class Program
{
    static void Main(string[] args)
    {
        // Configurar la consola para usar UTF-8
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Eleccion menu = new Eleccion();
        menu.MenuPrincipal();
        
    }
}
