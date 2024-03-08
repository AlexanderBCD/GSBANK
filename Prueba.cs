using System;

class Program
{
    static void Main()
    {
        Console.Write("Introduce el culángulo en grados: ");
        double grados;

        while (!double.TryParse(Console.ReadLine(), out grados))
        {
            Console.WriteLine("Entrada no válida. Por favor, introduce un número.");
            Console.Write("Introduce el ángulo en grados: ");
        }

        double radianes = ConvertirAGradosARadianes(grados);

        Console.WriteLine($"{grados} grados es igual a {radianes} radianes.");
    }
    static double ConvertirAGradosARadianes(double grados)
    {
        return grados * Math.PI / 180.0;
    }
}
