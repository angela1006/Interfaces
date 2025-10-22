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
            int[] numeros = { 2, 4, 7, 5, 6, 1 };

            int posicion = PosicionDelMenor(numeros);

            Console.WriteLine("El numero menor es: " + numeros[posicion]);
        }

        static int PosicionDelMenor(int[] array)
        {
            int numeroMenor = array[0];
            int posicion = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < numeroMenor)
                {
                    numeroMenor = array[i];
                    posicion = i;
                }
            }
            return posicion;
        }
    }
}
