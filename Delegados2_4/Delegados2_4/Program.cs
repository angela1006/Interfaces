using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegados2_4
{
    delegate int Operacion(int x, int y);
    internal class Program
    {
        static int Sumar(int x, int y) => x + y;
        static int Restar(int x, int y) => x - y;
        static int Multiplicar(int x, int y) => x * y;
        static int Dividir(int x, int y)
        {
            if (y == 0)
            {
                Console.WriteLine("Error: No es posible dividir por cero");
                return int.MinValue;
            }
            else return x / y;
        }

        static void Main(string[] args)
        {
            Operacion metodo = Sumar;
            metodo += Restar;
            metodo += Multiplicar;
            metodo += Dividir;  

            foreach (Operacion metodos in metodo.GetInvocationList())
            {
                int resultado = metodos(2, 0);
                if (resultado != int.MinValue)
                {
                    Console.WriteLine(resultado);
                }
            }
        }
    }
}