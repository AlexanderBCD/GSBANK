namespace GSBANK;

class Eleccion
{
    public void Menu()
    {
        
        Console.WriteLine("Bienvenido al Sistema de resguardo de Sangre");
        Console.WriteLine("********Opciones disponibles********");
        Console.WriteLine("1.- Usuarios registrados");
        Console.WriteLine("2. Registro de nuevo usuario");
        Console.WriteLine("3. Emparejamiento");
        Console.WriteLine("4. Bajas de usuario");
        Console.WriteLine("5. Salir del programa");
        int input = Convert.ToInt32(Console.ReadLine());

        switch(input)
        {
            case 1:

            break;

            case 3:

            break;

            case 4:

            break;

            case 5:

            return;
        }

    }
}