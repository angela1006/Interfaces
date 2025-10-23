using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegados2_1
{
    delegate int Operacion(int x, int y);
    internal class Program
    {
        static int Sumar(int x, int y) => x + y;
        static void Main(string[] args)
        {
            Operacion metodo = Sumar;

            
            Console.WriteLine(metodo(2, 2));
        }
    }
}
