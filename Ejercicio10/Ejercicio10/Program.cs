using System;
class Program
{
    static void Main(string[] args)
    {
        Banco banco = new Banco();
        banco.Operar();
        banco.ObtenerEstado();

        Console.ReadLine(); 
    }
}
class Cliente
{
    private string nombre;
    private double cantidadTotal;

    public Cliente(string nombre)
    {
        this.nombre = nombre;
        this.cantidadTotal = 0;
    }

    public void Ingresar(double cantidad)
    {
        if (cantidad > 0)
        {
            cantidadTotal += cantidad;
        }
        else
        {
            Console.WriteLine("No se puede ingresar una cantidad negativa o cero.");
        }
    }

    public void Sacar(double cantidad)
    {
        if (cantidad > 0 && cantidad <= cantidadTotal)
        {
            cantidadTotal -= cantidad;
        }
        else
        {
            Console.WriteLine("No se puede sacar esa cantidad.");
        }
    }

    public double GetCantidadTotal()
    {
        return cantidadTotal;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Cliente: {nombre}, Dinero: {cantidadTotal} euros");
    }
}

class Banco
{
    private Cliente[] clientes;

    public Banco()
    {
        clientes = new Cliente[3];
        clientes[0] = new Cliente("Andrea");
        clientes[1] = new Cliente("Carlos");
        clientes[2] = new Cliente("Paola");
    }

    public void Operar()
    {
        clientes[0].Ingresar(215000);
        clientes[1].Ingresar(91);
        clientes[2].Ingresar(60000000000);
        clientes[1].Sacar(5);
        clientes[2].Sacar(6541);
    }

    public void ObtenerEstado()
    {
        double totalBanco = 0;
        foreach (var cliente in clientes)
        {
            totalBanco += cliente.GetCantidadTotal();
        }
        Console.WriteLine($"Dinero total en el banco: {totalBanco} euros");

        foreach (var cliente in clientes)
        {
            cliente.MostrarInformacion();
        }
    }
}


