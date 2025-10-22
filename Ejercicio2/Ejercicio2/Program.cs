using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EJERCICIO 2

            Console.Write("Introduce una cadena de texto: ");
            string texto = Console.ReadLine();

            int cantidadEspacios = ContarEspacios(texto);

            Console.WriteLine($"\nLa cadena contiene {cantidadEspacios} espacios en blanco.");
        }
        static int ContarEspacios(string cadena)
        {
            int contador = 0;

            foreach (char c in cadena)
            {
                if (c == ' ')
                {
                    contador++;
                }
            }

            return contador;

        }
    }
}
