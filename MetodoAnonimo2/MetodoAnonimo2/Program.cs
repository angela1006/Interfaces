using System;

namespace MetodoAnonimo1
{
    public class Program
    {
        public delegate bool ValidarEdades(int x);

        static void ImprimirConsola(ValidarEdades validar, int edad)
        {
            Console.WriteLine(validar(edad));
        }

        static void Main(string[] args)
        {
            ValidarEdades validate = delegate (int edad)
            {
                return edad > 18;
            };
            ImprimirConsola(validate, 19);
            ImprimirConsola(validate, 20);
            ImprimirConsola(validate, 15);
        }
    }
}
