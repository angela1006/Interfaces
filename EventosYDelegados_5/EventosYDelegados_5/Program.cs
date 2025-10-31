using System;

namespace EventosYDelegados_5
{
    public class EnergiaEventArgs : EventArgs
    {
        public double ConsumoActual { get; set; }
        public double UmbralEstablecido { get; set; }
        public DateTime HoraDeteccion { get; set; }

        public EnergiaEventArgs(double consumoActual, double umbralEstablecido)
        {
            ConsumoActual = consumoActual;
            UmbralEstablecido = umbralEstablecido;
            HoraDeteccion = DateTime.Now;
        }
    }

    public class MonitorEnergia
    {
        private const double UMBRAL_MAXIMO = 500.0;

        public event EventHandler<EnergiaEventArgs> ConsumoExcesivoDetectado;

        public double Umbral { get; }

        public MonitorEnergia(double umbralInicial = UMBRAL_MAXIMO)
        {
            Umbral = umbralInicial;
             Console.WriteLine($"Monitor: Umbral de consumo establecido en {Umbral:F2} W/h.");
        }

        // Simula registro y verifica el consumo
        public void RegistrarConsumo(double consumo)
        {
            Console.WriteLine($"\nMonitor: Registrando consumo actual: {consumo:F2} W/h.");

            // Verifica si el consumo supera el umbral
            if (consumo > Umbral)
            {
                Console.WriteLine($"Monitor: Consumo ({consumo:F2}) ha superado el umbral ({Umbral:F2}).");

                OnConsumoExcesivoDetectado(new EnergiaEventArgs(consumo, Umbral));
            }
            else
            {
                Console.WriteLine($"Monitor: Consumo OK ({consumo:F2}). Por debajo del umbral.");
            }
        }

        protected virtual void OnConsumoExcesivoDetectado(EnergiaEventArgs e)
        {
            ConsumoExcesivoDetectado?.Invoke(this, e);
        }
    }



    // envía una advertencia al usuario.
    public class ServicioNotificacion
    {
        public void EnviarAdvertencia(object sender, EnergiaEventArgs e)
        {
            Console.WriteLine("\n--- RESPUESTA: Servicio Notificación ---");
            Console.WriteLine($"Se ha detectado un consumo de {e.ConsumoActual:F2} W/h.");
            Console.WriteLine($"    Por favor, revise sus dispositivos. Debe ahorrar energía");
        }
    }

    // ajusta dispositivos para reducir el consumo.
    public class ServicioAjusteAutomatizado
    {
        public void AjustarDispositivos(object sender, EnergiaEventArgs e)
        {
            Console.WriteLine("\n--- RESPUESTA: Servicio Ajuste Automatizado ---");
            double exceso = e.ConsumoActual - e.UmbralEstablecido;

            Console.WriteLine($"Activando modo ahorro. Consumo en exceso: {exceso:F2} W/h.");
            Console.WriteLine("    Acción: Reduciendo brillo de luces y apagando dispositivos en stand-by.");
            Console.WriteLine("---------------------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Sistema de Supervisión de Consumo de Energía ---");

            var monitor = new MonitorEnergia(umbralInicial: 450.0);

            var servicioNotificacion = new ServicioNotificacion();
            var servicioAjuste = new ServicioAjusteAutomatizado();

            monitor.ConsumoExcesivoDetectado += servicioNotificacion.EnviarAdvertencia;
            monitor.ConsumoExcesivoDetectado += servicioAjuste.AjustarDispositivos;

            Console.WriteLine("\n================ SIMULACIÓN 1: Consumo Normal (300 W/h) ================");
            monitor.RegistrarConsumo(300.50);

            Console.WriteLine("\n================ SIMULACIÓN 2: Consumo EXCESIVO (620 W/h) ================");
            monitor.RegistrarConsumo(620.75);
        }
    }
}