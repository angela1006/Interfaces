using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce la base: ");
            int baseNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduce el exponente: ");
            int exponente = int.Parse(Console.ReadLine());

            int resultadoIterativo = PotenciaIterativa(baseNum, exponente);
            Console.WriteLine($"Potencia iterativa: {baseNum}^{exponente} = {resultadoIterativo}");

            int resultadoRecursivo = PotenciaRecursiva(baseNum, exponente);
            Console.WriteLine($"Potencia recursiva: {baseNum}^{exponente} = {resultadoRecursivo}");
        }

        static int PotenciaIterativa(int baseNum, int exponente)
        {
            int resultado = 1;
            for (int i = 0; i < exponente; i++)
            {
                resultado *= baseNum;
            }
            return resultado;
        }

        static int PotenciaRecursiva(int baseNum, int exponente)
        {
            if (exponente == 0)
                return 1;
            else
                return baseNum * PotenciaRecursiva(baseNum, exponente - 1);
        }
    }
}
