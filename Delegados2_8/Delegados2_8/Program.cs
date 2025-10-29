using System;

namespace Delegados2_8
{
    delegate int Transformar(int numero);

    internal class Program
    {
        static int Doblar(int numero) => numero * 2;
        static int Triplicar(int numero) => numero * 3;
        static int Cuadrado(int numero) => numero * numero;

        static void Main(string[] args)
        {
            Transformar operaciones = Doblar;
            operaciones += Triplicar;
            operaciones += Cuadrado;

            int numero = 5; 

            foreach (Transformar op in operaciones.GetInvocationList())
            {
                string nombreMetodo = op.Method.Name;
                int resultado = op(numero);
                Console.WriteLine($"{nombreMetodo}({numero}) = {resultado}");
            }

            Console.ReadLine();
        }
    }
}
