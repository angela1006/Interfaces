using System;

namespace Delegados2_9
{
    delegate int OperacionCallback(int a, int b);

    internal class Program
    {
        static int Suma(int a, int b) => a + b;
        static int Resta(int a, int b) => a - b;
        static int Multiplicar(int a, int b) => a * b;

        static int EjecutarOperacion(OperacionCallback operacion, int x, int y)
        {
            return operacion(x, y);
        }

        static void Main(string[] args)
        {
            int a = 6;
            int b = 3;

            int resultadoSuma = EjecutarOperacion(Suma, a, b);
            int resultadoResta = EjecutarOperacion(Resta, a, b);
            int resultadoMultiplicar = EjecutarOperacion(Multiplicar, a, b);

            Console.WriteLine($"Suma({a}, {b}) = {resultadoSuma}");
            Console.WriteLine($"Resta({a}, {b}) = {resultadoResta}");
            Console.WriteLine($"Multiplicar({a}, {b}) = {resultadoMultiplicar}");

            Console.ReadLine();
        }
    }
}
