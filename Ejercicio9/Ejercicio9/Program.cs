using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { 8, 4, 9, 2, 6, 10 };

            int posicion = PosicionDelMenor(numeros);

            Console.WriteLine("El numero menor es: " + numeros[posicion]);
        }

        static int PosicionDelMenor(int[] array)
        {
            int menor = array[0];
            int posicion = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < menor)
                {
                    menor = array[i];
                    posicion = i;
                }
            }
            return posicion;
        }
    }
}
