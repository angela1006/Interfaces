using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosYDelegados_3
{
    public class BackupEventArgs : EventArgs
    {
        public string NombreArchivo { get; }
        public DateTime FechaBackup { get; }

        public BackupEventArgs(string nombreArchivo, DateTime fechaBackup)
        {
            NombreArchivo = nombreArchivo;
            FechaBackup = fechaBackup;
        }
    }

    // gestiona los backups
    public class GestorBackups
    {
        public event EventHandler<BackupEventArgs> BackupCompletado;

        public void CrearBackup(string nombreArchivo)
        {
            Console.WriteLine($"Realizando backup del archivo: {nombreArchivo}");
            System.Threading.Thread.Sleep(500);     

            OnBackupCompletado(new BackupEventArgs(nombreArchivo, DateTime.Now));
        }
        protected virtual void OnBackupCompletado(BackupEventArgs e)
        {
            BackupCompletado?.Invoke(this, e);
        }
    }

    //  envio notificaciones
    public class ServicioNotificacion
    {
        public void OnBackupCompletado(object sender, BackupEventArgs e)
        {
            Console.WriteLine($"NOTIFICACIÓN: Backup del archivo '{e.NombreArchivo}' completado el {e.FechaBackup}");
        }
    }

    // registro la operación de backup
    public class ServicioLog
    {
        public void OnBackupCompletado(object sender, BackupEventArgs e)
        {
            Console.WriteLine($"LOG: Backup registrado para '{e.NombreArchivo}' a las {e.FechaBackup}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GestorBackups gestor = new GestorBackups();

            ServicioNotificacion notificacion = new ServicioNotificacion();
            ServicioLog log = new ServicioLog();

            gestor.BackupCompletado += notificacion.OnBackupCompletado;
            gestor.BackupCompletado += log.OnBackupCompletado;

            string[] archivos = { "documento1.txt", "imagen.png", "datos.csv" };
            foreach (var archivo in archivos)
            {
                gestor.CrearBackup(archivo);
            }
        }
    }
}
