using System;

namespace Delegados2_10
{
    delegate double Calculo(double numero);

    internal class Program
    {
        static double RaizCuadrada(double numero)
        {
            return Math.Sqrt(numero);
        }

        static double Logaritmo(double numero)
        {
            return Math.Log(numero);
        }

        static void EjecutarCalculo(Calculo operacion, double numero)
        {
            try
            {
                double resultado = operacion(numero);
                Console.WriteLine($"{operacion.Method.Name}({numero}) = {resultado}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar {operacion.Method.Name}({numero}): {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            double numero1 = 16;
            double numero2 = -4;
            double numero3 = 0;

            Calculo raiz = RaizCuadrada;
            Calculo log = Logaritmo;

            EjecutarCalculo(raiz, numero1);   
            EjecutarCalculo(raiz, numero2);
            EjecutarCalculo(log, numero1);    
            EjecutarCalculo(log, numero3);    
            EjecutarCalculo(log, numero2);  

            Console.ReadLine();
        }
    }
}
