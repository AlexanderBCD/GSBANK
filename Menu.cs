namespace GSBANK;

class Eleccion
{
    public void Menu()
    {
        
        Console.WriteLine("Bienvenido al Sistema de resguardo de Sangre");
        while(true)
        {
            Console.Clear();
            Console.WriteLine("********Opciones disponibles********");
            Console.WriteLine("1.- Usuarios registrados");
            Console.WriteLine("2. Registro de nuevo usuario");
            Console.WriteLine("3. Emparejamiento");
            Console.WriteLine("4. Bajas de usuario");
            Console.WriteLine("5. Salir del programa");
            Console.Write("Introducir opcion: ");
            int input = Convert.ToInt32(Console.ReadLine());

            switch(input)
            {
                case 1:

                break;

                case 2:

                break;

                case 3:

                break;

                case 4:

                break;

                case 5:

                return;

                default:

                Console.WriteLine("Revisar las opciones dispobibles. La opción que eligió es inexistente");
            
                break;
            }

        }
        

    }
}