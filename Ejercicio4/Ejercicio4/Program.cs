using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduce un número entero: ");

            int numero = int.Parse(Console.ReadLine());

            if (EsPrimo(numero))
                Console.WriteLine($"{numero} es un número primo.");
            else
                Console.WriteLine($"{numero} no es un número primo.");
        }
        static bool EsPrimo(int numero)
        {
            if (numero <= 1) return false;

            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                    return false;
            }

            return true;
        }
    }
 }


