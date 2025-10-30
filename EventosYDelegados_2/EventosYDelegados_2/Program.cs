using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosYDelegados_2
{
    using System;

    //información  evento
    public class TemperaturaEventArgs : EventArgs
    {
        public double TemperaturaActual { get; }
        public double Umbral { get; }

        public TemperaturaEventArgs(double temperaturaActual, double umbral)
        {
            TemperaturaActual = temperaturaActual;
            Umbral = umbral;
        }
    }

    // control de temperatura
    public class ControlTemperatura
    {
        private double umbral;

        public ControlTemperatura(double umbral)
        {
            this.umbral = umbral;
        }

        public event EventHandler<TemperaturaEventArgs> TemperaturaAlta;

        //medición de temperatura
        public void MedirTemperatura(double temperatura)
        {
            Console.WriteLine($"Temperatura: {temperatura}°C");

            if (temperatura > umbral)
            {
                OnTemperaturaAlta(new TemperaturaEventArgs(temperatura, umbral));
            }
        }

        protected virtual void OnTemperaturaAlta(TemperaturaEventArgs e)
        {
            TemperaturaAlta?.Invoke(this, e);
        }
    }

    public class ServicioAlerta
    {
        public void OnTemperaturaAlta(object sender, TemperaturaEventArgs e)
        {
            Console.WriteLine($"ALERTA: {e.TemperaturaActual}°C supera el umbral de {e.Umbral}°C");
        }
    }

    //registro temperatura
    public class ServicioRegistroTemperatura
    {
        public void OnTemperaturaAlta(object sender, TemperaturaEventArgs e)
        {
            Console.WriteLine($"Registro: temperatura {e.TemperaturaActual}°C (umbral {e.Umbral}°C)");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ControlTemperatura control = new ControlTemperatura(30);

            ServicioAlerta alerta = new ServicioAlerta();
            ServicioRegistroTemperatura registro = new ServicioRegistroTemperatura();

            control.TemperaturaAlta += alerta.OnTemperaturaAlta;
            control.TemperaturaAlta += registro.OnTemperaturaAlta;

            double[] temperaturas = { 25, 28, 32, 35, 29 };
            foreach (var temp in temperaturas)
            {
                control.MedirTemperatura(temp);
            }
        }
    }
}
