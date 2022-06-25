class Producto
{
    public string? Nombre { get; set; }
    public DateTime FechaDeVencimiento { get; set; }
    public int Precio { get; set; }
    public string? Tamano { get; set; }

    public Producto(string nombre, DateTime fechaDeVencimiento, int precio, string tamano)
    {
        Nombre = nombre;
        FechaDeVencimiento = fechaDeVencimiento;
        Precio = precio;
        Tamano = tamano;
    }

    public Producto()
    {

    }

    public void MostrarProducto()
    {
        Console.WriteLine($"\nNombre:\t\t\t{Nombre}");
        Console.WriteLine($"Fecha de vencimiento:\t{FechaDeVencimiento.ToShortDateString()}");
        Console.WriteLine($"Precio:\t\t\t{Precio}");
        Console.WriteLine($"Tamaño:\t\t\t{Tamano}");
    }
}