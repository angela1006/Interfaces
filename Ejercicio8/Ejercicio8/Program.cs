using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce un número: ");
            int numero = int.Parse(Console.ReadLine());

            int suma = SumaDigitos(numero);

            Console.WriteLine($"La suma de los dígitos de {numero} es: {suma}");
        }

        static int SumaDigitos(int n)
        {
            int suma = 0;
            n = Math.Abs(n);

            while (n > 0)
            {
                int digito = n % 10;
                suma += digito;
                n /= 10;
            }

            return suma;
        }
    }
}
