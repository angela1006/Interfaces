using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduce un número entero: ");
            if ( numero >= 0)
            {
                long resultado = Factorial(numero);
                Console.WriteLine($"{numero}! = {resultado}");
            }
            else
            {
                Console.WriteLine("Entrada no válida.");
            }
        }
        static long Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Error el numero es negativo");
            }
            if (n == 0 || n == 1)
            {
                return 1; 
            }
            return n * Factorial(n - 1); 
        }
    }
}
