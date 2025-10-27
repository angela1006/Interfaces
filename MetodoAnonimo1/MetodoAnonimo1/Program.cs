using System;

namespace MetodoAnonimo1
{
    public class Program
    {
        public delegate bool ValidarEdades(int x);

        static void Main(string[] args)
        {
            ValidarEdades validate = delegate (int edad)
            {
                return edad > 18;
            };

            Console.WriteLine( validate(20)); 
            Console.WriteLine(validate(15));
        }
    }
}
