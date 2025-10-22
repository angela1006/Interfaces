using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EJERCICIO 6
            int intentos = 3;
            bool loginExitoso = false;

            while (intentos > 0 && !loginExitoso)
            {
                Console.Write("Introduce el usuario: ");
                string usuario = Console.ReadLine();

                Console.Write("Introduce la contraseña: ");
                string contraseña = Console.ReadLine();

                if (ValidarLogin(usuario, contraseña))
                {
                    Console.WriteLine("¡Login realizado!");
                    loginExitoso = true;
                }
                else
                {
                    intentos--;
                    Console.WriteLine($"Usuario o contraseña incorrectos. Te quedan {intentos} intento(s).");
                }
            }

            if (!loginExitoso)
            {
                Console.WriteLine("Has agotado los intentos.");
            }
        }

        static bool ValidarLogin(string usuario, string contraseña)
        {
            return usuario == "usuario2DAM" && contraseña == "pass2DAM";
        }
    }
}
