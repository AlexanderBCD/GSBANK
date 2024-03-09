

namespace GSBANK;

class Eleccion
{
    public void MenuPrincipal()
    {
        while(true)
        {
            Console.Clear(); //LIMPIA CONSOLA OJO
            Console.WriteLine("🩸 Bienvenido al Sistema de Resguardo de Sangre 🩸");

            Console.WriteLine("\n******** Opciones Disponibles ********");
            Console.WriteLine("1. 🧑‍🤝‍🧑 Usuarios Registrados");
            Console.WriteLine("2. ➕ Registro de Nuevo Usuario");
            Console.WriteLine("3. 💞 Emparejamiento");
            Console.WriteLine("4. 🚫 Bajas de Usuario");
            Console.WriteLine("5. 🚪 Salir del Programa");
            Console.Write("--Introduce tu opción: 👉 ");
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

                return;

                default:

                Console.WriteLine("Revisar las opciones dispobibles...\n. La opción que eligió es inexistente [ENTER]");
                Console.ReadKey();
            
                break;
            }

        }
        

    }
}