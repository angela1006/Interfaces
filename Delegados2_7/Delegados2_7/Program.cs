using System;

namespace Delegados2_7
{
    delegate int OperacionArray(int[] numeros);

    internal class Program
    {
        static int Sumar(int[] numeros)
        {
            int suma = 0;
            foreach (int n in numeros)
            {
                suma += n;
            }
            return suma;
        }

        static int Multiplicar(int[] numeros)
        {
            int producto = 1;
            foreach (int n in numeros)
            {
                producto *= n;
            }
            return producto;
        }

        static void Main(string[] args)
        {
            OperacionArray operaciones = Sumar;
            operaciones += Multiplicar;

            int[] numeros = { 2, 3, 4 };

            foreach (OperacionArray op in operaciones.GetInvocationList())
            {
                string nombreMetodo = op.Method.Name;
                int resultado = op(numeros);
                Console.WriteLine($"{nombreMetodo}: {resultado}");
            }

            Console.ReadLine();
        }
    }
}
