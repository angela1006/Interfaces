using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Delegados1
{
    internal class Program
    {
        public delegate bool ValidarNumero(int x);

        static bool validate(int x)
        {
            if (x > 0) return true;
            else return false;
        }
        static void Main(string[] args)
        {
            ValidarNumero vn = validate;
            Console.WriteLine(vn(-2));
        }
    }
}
