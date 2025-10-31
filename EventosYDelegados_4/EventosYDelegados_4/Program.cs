using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosYDelegados_4
{
    public class IntrusoEventArgs : EventArgs
    {
        public string NombreSensor { get; set; }
        public DateTime HoraDeteccion { get; set; }

        public IntrusoEventArgs(string nombreSensor, DateTime horaDeteccion)
        {
            NombreSensor = nombreSensor;
            HoraDeteccion = horaDeteccion;
        }
    }

    
    public class SensorMonitoreo
    {
        private const int HORA_INICIO_PERMITIDA = 7;
        private const int HORA_FIN_PERMITIDA = 22;

        public event EventHandler<IntrusoEventArgs> AlertaIntruso;
        private readonly string _nombre;

        public SensorMonitoreo(string nombre)
        {
            _nombre = nombre;
        }

        public void SimularApertura(DateTime horaSimulada)
        {
            Console.WriteLine($"\n[{_nombre}]: Se ha detectado una **APERTURA** (Hora de prueba: {horaSimulada.ToShortTimeString()}).");

            DateTime ahora = horaSimulada;

            // logixa de Alerta
            if (ahora.Hour < HORA_INICIO_PERMITIDA || ahora.Hour >= HORA_FIN_PERMITIDA)
            {
                Console.WriteLine($"{_nombre}: **ALERTA** Horario NO permitido ({ahora.ToShortTimeString()}).");

                OnAlertaIntruso(new IntrusoEventArgs(_nombre, ahora));
            }
            else
            {
                Console.WriteLine($"{_nombre}: **HORARIO PERMITIDO** {ahora.ToShortTimeString()}). No hay alerta.");
            }
        }

        protected virtual void OnAlertaIntruso(IntrusoEventArgs e)
        {
            AlertaIntruso?.Invoke(this, e);
        }
    }

    public class ServicioAlarma
    {
        public void Activar(object sender, IntrusoEventArgs e)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine($"ALARMA ACTIVADA: detecion a las {e.HoraDeteccion.ToLongTimeString()} en: {e.NombreSensor}");
            Console.WriteLine("=================================================");
        }
    }

    public class ServicioRegistroIncidencias
    {
        public void Registrar(object sender, IntrusoEventArgs e)
        {
            Console.WriteLine($"REGISTRO BD: Guardando incidencia");
            Console.WriteLine($"   > Sensor: {e.NombreSensor}");
            Console.WriteLine($"   > Hora del evento: {e.HoraDeteccion.ToString("dd/MM/yyyy HH:mm:ss")}");
            Console.WriteLine("-------------------------------------------------"); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Sistema de Monitoreo de Sensores ---");

            var sensorPuerta = new SensorMonitoreo("Puerta Principal");
            var sensorVentana = new SensorMonitoreo("Ventana del Salón");

            var alarma = new ServicioAlarma();
            var registro = new ServicioRegistroIncidencias();

            sensorPuerta.AlertaIntruso += alarma.Activar;
            sensorPuerta.AlertaIntruso += registro.Registrar;
            sensorVentana.AlertaIntruso += alarma.Activar;
            sensorVentana.AlertaIntruso += registro.Registrar;

            var hora2300 = new DateTime(2025, 1, 1, 23, 0, 0); 
            var hora1000 = new DateTime(2025, 1, 1, 10, 0, 0);  
            var hora0500 = new DateTime(2025, 1, 1, 5, 0, 0);

            // activa alarma
            Console.WriteLine("\n========== SIMULACIÓN 1: Fuera de Horario (23:00) ==========");
            sensorPuerta.SimularApertura(hora2300);

            // no activa alerta
            Console.WriteLine("\n========== SIMULACIÓN 2: Dentro de Horario (10:00) ==========");
            sensorVentana.SimularApertura(hora1000);
            Console.ReadKey(); 
        }
    }
}