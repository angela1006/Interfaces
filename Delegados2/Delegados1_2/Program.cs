using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Delegados2
{
    internal class Program
    {
        public delegate void ValidarNumero(int x);

        public static void MayorACero(int a)
        {
            Console.WriteLine(a > 0);
        }
        static void esPar(int x)
        {
            Console.WriteLine(x % 2 == 0);
        }
        static void Main(string[] args)
        {
            ValidarNumero validate = MayorACero;

            validate += esPar;
            validate(3);
            validate(3);
        }
    }
 }