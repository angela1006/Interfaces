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
            Console.Write("Introduce un número entero no negativo: ");
            if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 0)
            {
                long resultado = Factorial(numero);
                Console.WriteLine($"{numero}! = {resultado}");
            }
            else
            {
                Console.WriteLine("Entrada no válida. Debes introducir un número entero no negativo.");
            }
        }
        static long Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("El número debe ser no negativo.");
            }
            if (n == 0 || n == 1)
            {
                return 1; 
            }
            return n * Factorial(n - 1); 
        }
    }
}
