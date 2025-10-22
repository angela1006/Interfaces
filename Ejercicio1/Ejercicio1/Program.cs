using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EJERCICIO 1
            Console.WriteLine("Introduce el tamaño del array: ");
            int tamaño;
            tamaño = int.Parse(Console.ReadLine());

            int[] numeros = new int[tamaño];

            for (int i = 0; i < tamaño; i++)
            {
                Console.Write($"Introduce el valor #{i + 1}: ");
                numeros[i] = int.Parse(Console.ReadLine());
            }

            int suma = 0;
            foreach (int numero in numeros)
            {
                suma += numero;
            }

            double media = (double)suma / tamaño;

            Console.WriteLine($"\nLa suma del array es: {suma}");
            Console.WriteLine($"La media del array es: {media}");
        }
    }
}
