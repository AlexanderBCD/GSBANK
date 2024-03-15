namespace GSBANK;

class Emparejamiento
{
    public void Compatibles()
    {
        bool estado = false;
        while(!estado){
            
            Console.WriteLine("Sistema de emparejamiento para donaciones de sangre");
            Console.Write("Ingresar los nombres: ");
            string? input = Console.ReadLine();

            Console.Write("Ingrese Apellido Paterno: ");
            string? input2 = Console.ReadLine();

            Console.Write("Ingrese Apellido Materno: ");
            string? input3 = Console.ReadLine();


            HelperEmparejamiento help = new HelperEmparejamiento();
            string[]? resultado = help.ConsultarId(input, input2,input3);

            if(resultado != null)
            {
                estado = true;
                string port1 = resultado[0];
                string port2 = resultado[1];
                
                Console.WriteLine($"Tipo de sangre: {port1} {port2} ");

                Console.WriteLine("Donantes compatibles: ");

                help.PersonasCompatibles(port1,port2);
                

                Console.ReadKey();
            }
        }
        
    }
}