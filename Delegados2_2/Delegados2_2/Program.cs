using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegados2_2
{
    delegate int Operacion(int x, int y);
    internal class Program
    {
        static int Sumar(int x, int y) => x + y;
        static int Restar(int x, int y) => x - y;

        static void Main(string[] args)
        {
            Operacion metodo = Sumar;
            metodo += Restar;

            foreach(Operacion metodos in metodo.GetInvocationList())
            {
                Console.WriteLine(metodos(2, 2));
            }
        }
    }
}
