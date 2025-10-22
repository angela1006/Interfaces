using System;

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
