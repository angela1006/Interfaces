using System;

namespace Delegados2_6
{
    // 1. Definir el delegado
    delegate int Operacion(int x, int y);

    internal class Program
    {
        // 2. Definir los métodos
        static int Sumar(int x, int y) => x + y;
        static int Restar(int x, int y) => x - y;
        static int Multiplicar(int x, int y) => x * y;

        static void Main(string[] args)
        {
            // 3. Asignar métodos al delegado
            Operacion operaciones = Sumar;
            operaciones += Restar;
            operaciones += Multiplicar;

            int a = 5;
            int b = 3;

            // 4. Ejecutar cada método y mostrar nombre + resultado
            foreach (Operacion op in operaciones.GetInvocationList())
            {
                // Nombre del método
                string nombreMetodo = op.Method.Name;

                // Resultado
                int resultado = op(a, b);

                Console.WriteLine($"{nombreMetodo}: {resultado}");
            }

            Console.ReadLine();
        }
    }
}
