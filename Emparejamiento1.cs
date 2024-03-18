using System.Text.RegularExpressions;

namespace GSBANK;

class Emparejamiento
{
    public void Compatibles()
    {
        bool estado = false;
        string? input ="";
        string? input2 ="";
        string? input3 ="";
        while(!estado){
            Console.Clear();
            Console.WriteLine("Sistema de emparejamiento para donaciones de sangre");
            do
            {
                Console.Clear();
                Console.Write("Ingresar los nombres: ");
                input = Console.ReadLine() ?? string.Empty;
            }
            while(!TextoCorrecto(input));
            
            do
            {
                Console.Clear();
                Console.Write("Ingrese Apellido Paterno: ");
                input2 = Console.ReadLine() ??  string.Empty;
            }
            while(!TextoCorrecto(input2));

            do
            {
                Console.Clear();
                Console.Write("Ingrese Apellido Materno: ");
                input3 = Console.ReadLine() ?? string.Empty;
            }
            while(!TextoCorrecto(input3));


            HelperEmparejamiento help = new HelperEmparejamiento();
            string[]? resultado = help.ConsultarId(input, input2,input3);

            if(resultado != null)
            {
                estado = true;
                string port1 = resultado[0];
                string port2 = resultado[1];
                
                Console.WriteLine($"Tipo de sangre: {port1} {port2} ");

                Console.WriteLine("Donantes compatibles: ");

                help.PersonasCompatibles(port1,port2,input,input2);
                

                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Datos erroneos o el usuario no se encuentra en la base de datos");
                Console.ReadKey();
            }
        }
        
    }
     static bool TextoCorrecto(string texto){

        Regex regex = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$");
        return regex.IsMatch(texto);

     }
}