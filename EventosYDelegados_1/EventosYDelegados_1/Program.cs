using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosYDelegados_1
{
    using System;

    //información de la venta
    public class VentaEventArgs : EventArgs
    {
        public string Producto { get; set; }
        public decimal Precio { get; set; }

        public VentaEventArgs(string producto, decimal precio)
        {
            Producto = producto;
            Precio = precio;
        }
    }

    // emite el evento
    public class RegistroVentas
    {
        public event EventHandler<VentaEventArgs> VentaRealizada;

        public void ProcesarVenta(string producto, decimal precio)
        {
            Console.WriteLine($"Procesando venta de: {producto} por {precio}$");
            OnVentaRealizada(new VentaEventArgs(producto, precio));
        }

        // invocar el evento
        protected virtual void OnVentaRealizada(VentaEventArgs e)
        {
            VentaRealizada?.Invoke(this, e);
        }
    }

    //registra la venta
    public class ServicioRegistro
    {
        public void RegistrarVenta(object sender, VentaEventArgs e)
        {
            Console.WriteLine($"[ServicioRegistro] Venta registrada: {e.Producto} - {e.Precio}$");
        }
    }

    // notificar usuario
    public class ServicioNotificacion
    {
        public void EnviarNotificacionVenta(object sender, VentaEventArgs e)
        {
            Console.WriteLine($"[ServicioNotificacion] Notificación enviada: Has vendido {e.Producto} por {e.Precio}$.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            RegistroVentas registroVentas = new RegistroVentas();
            ServicioRegistro servicioRegistro = new ServicioRegistro();
            ServicioNotificacion servicioNotificacion = new ServicioNotificacion();

            registroVentas.VentaRealizada += servicioRegistro.RegistrarVenta;
            registroVentas.VentaRealizada += servicioNotificacion.EnviarNotificacionVenta;
            registroVentas.ProcesarVenta("Laptop", 1500.00m);
            registroVentas.ProcesarVenta("Smartphone", 800.00m);

            Console.WriteLine("\nOulsa una tecla para finalizar");
            Console.ReadKey();
        }
    }

}
