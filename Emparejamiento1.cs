namespace GSBANK;

class Emparejamiento
{
    public void Compatibles()
    {
        int id;
        bool estado = false;
        

        while(!estado){
            
            Console.WriteLine("Sistema de emparejamiento para donaciones de sangre");
            Console.Write("Ingresar el [id] del paciente");
            string? input = Console.ReadLine();

            if(int.TryParse(input, out  id))
            {
                estado = true;
            }
            else
            {
                Console.WriteLine("Dato erroneo, favor de ingresar un dato valido");
            }

            HelperEmparejamiento help = new HelperEmparejamiento();
            string[]? resultado = help.ConsultarId(id);

            if(resultado != null)
            {
                string port1 = resultado[0];
                string port2 = resultado[1];
                string port3 = resultado[2];

                Console.WriteLine($"Usuario: {port1} {port2} {port3}");

                Console.ReadKey();
            }
        }
        
    }
}