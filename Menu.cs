namespace GSBANK;

class Menu
{
    public void MostrarMenuPrincipa()
    {
        Console.Clear(); //LIMPIA CONSOLA OJO
        Console.WriteLine("🩸 Bienvenido al Sistema de Resguardo de Sangre 🩸");

        Console.WriteLine("\n******** Opciones Disponibles ********");
        Console.WriteLine("\n1. 🧑 Usuarios Registrados");
        Console.WriteLine("2. ➕ Registro de Nuevo Usuario");
        Console.WriteLine("3. 💞 Emparejamiento");
        Console.WriteLine("4. 🚫 Bajas de Usuario");
        Console.WriteLine("5. 🚪 Salir del Programa");
        Console.Write("\n--Introduce tu opción 👉: ");
    }
}