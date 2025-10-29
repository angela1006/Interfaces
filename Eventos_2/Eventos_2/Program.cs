using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization; 

namespace Eventos_2 
{
    //Clase de transaccion con sus atributos
    public class Transaccion
    {
        public int identificador { get; set; }


        public int fechaTransformacion { get; set; }
    }

    //EventArg personalizado para un evento de transaccion
    public class TransaccionEventArgs : EventArgs
    {
        public Transaccion transaccion { get; set; }
    }

    //Clase para la gestion de pagos (Pasarela) - EL EMISOR
    public class PasarelaDePago
    {
        //Evento de fin de transaccion
        public event EventHandler<TransaccionEventArgs> TransaccionFinalizada;

        //metodo que dispara el evento de fin de transaccion
        protected virtual void EnTransaccinFinalizada(Transaccion transaccion_)
        {
            //disparo el evento de fin de transaccion, mediante una llamada al mismo, solo si es distinto de null
            if (TransaccionFinalizada != null)
                TransaccionFinalizada(this, new TransaccionEventArgs()
                {
                    transaccion = transaccion_,
                });
        }

        //metodo que procesa el pago mediante una transaccion
        public void Pago(Transaccion transaccion_)
        {
            Console.WriteLine("Procesando pago... por favor espere.");
            //procesando transaccion de pago
            Thread.Sleep(2000);

            Console.WriteLine("¡Pago completado!");
            EnTransaccinFinalizada(transaccion_);
        }
    }
 
    public class GestorEmail
    {
        public void EnTransaccionFinalizada(object source, TransaccionEventArgs e)
        {
            // Simula el envío de un email
            Console.WriteLine("\n--- Notificación Email ---");
            Console.WriteLine($"Enviando email: El pago con ID {e.transaccion.identificador} fue procesado correctamente.");
            Console.WriteLine("---------------------------------------------------------------\n");
        }
    }

    public class GestorDeFacturacion
    {
 
        public void EnTransaccionFinalizada(object source, TransaccionEventArgs e)
        {
            string dateStr = e.transaccion.fechaTransformacion.ToString();
            DateTime date = DateTime.ParseExact(dateStr, "yyyyMMdd", CultureInfo.InvariantCulture);
            string formattedDate = date.ToString("dd/MM/yyyy");

            // Imprime el mensaje de factura
            Console.WriteLine("\n--- Notificación de Facturación Recibida ---");
            Console.WriteLine($"La factura correspondiente a la transacción {e.transaccion.identificador} fue emitida con fecha {formattedDate}.");
            Console.WriteLine("------------------------------------------`--------------------\n");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var pasarela = new PasarelaDePago();
            var gestorEmail = new GestorEmail();

            var gestorFacturacion = new GestorDeFacturacion();

            pasarela.TransaccionFinalizada += gestorEmail.EnTransaccionFinalizada;

            pasarela.TransaccionFinalizada += gestorFacturacion.EnTransaccionFinalizada;

            var transaccion = new Transaccion() { identificador = 71645331, fechaTransformacion = 20100630 }; // 20100630 es 30/06/2010


            Console.WriteLine($"Iniciando proceso de pago para la transacción {transaccion.identificador}");
            pasarela.Pago(transaccion);

            Console.WriteLine("Pulsa una tecla para finalizar");
            Console.ReadKey();
        }
    }
}