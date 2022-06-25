using System.Text.Json;

//Bienvenida
Funcion.GenerarTitulo("BIENVENIDO");
Console.WriteLine("Indexador Productos:\n");

//Ruta del proyecto
string RutaDeLaCarpeta = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
string NombreDelArchivo = "productos.json";
string Ruta = RutaDeLaCarpeta + "//" + NombreDelArchivo;
Console.WriteLine($"Ruta del archivo JSON: {Ruta}");

//Inicializaciones
var ListaDeProductos = new List<Producto>();
string[] ArregloDeNombres = { "Coso", "Cosa", "Cosita", "Coso comue", "Chirimbolo", "Socotroco" };
string[] ArregloDeTamanos = { "200gr", "500gr", "1 unidad", "Docena", "Un poquito así más o menos" };
string ListaDeProductosSerializada;

//Control de archivo
if (!File.Exists(Ruta))
{
    Console.WriteLine($"El archivo {NombreDelArchivo} no existe. Se creará en la ruta designada.");
}

//Creando {Cantidad} productos aleatorios
Random rnd = new();
var Cantidad = rnd.Next(1,11);
Console.WriteLine("\nCreando listado de productos...");
Console.WriteLine($"Se crearán {Cantidad} productos aleatorios.");
for (int i = 0; i < Cantidad; i++)
{
    var Nombre = ArregloDeNombres.ElementAt(rnd.Next(ArregloDeNombres.Count()));
    var FechaDeVencimiento = new DateTime(2022,01,01).AddDays(rnd.Next(2000));
    var Precio = rnd.Next(50, 2000);
    var Tamano = ArregloDeTamanos.ElementAt(rnd.Next(ArregloDeTamanos.Count()));
    var NuevoProducto = new Producto(Nombre, FechaDeVencimiento, Precio, Tamano);
    ListaDeProductos.Add(NuevoProducto);
}
Console.WriteLine("Listado de productos creado.");

//FileStream
using (var FS = new FileStream(Ruta, FileMode.OpenOrCreate))
{
    //Escribiendo archivo
    using (var SW = new StreamWriter(FS))
    {
        //Por cada elemento
        //foreach (var UnProducto in ListaDeProductos)
        //{
        //    var UnProductoSerializado = JsonSerializer.Serialize(UnProducto);
        //    SW.WriteLine(UnProductoSerializado);
        //}

        //Por lista
        ListaDeProductosSerializada = JsonSerializer.Serialize(ListaDeProductos);
        SW.WriteLine(ListaDeProductosSerializada);

        Console.WriteLine("\nListado serializado correctamente. Revise la carpeta.");
    }
}

//Leyendo archivo
using (var FS = new FileStream(Ruta, FileMode.Open))
{
    using (var SR = new StreamReader(FS))
    {
        Console.WriteLine("\nMostrando el listado de productos:");
        var DatosLeidos = SR.ReadToEnd();
        var ListaDeProductosDeserializada = JsonSerializer.Deserialize<List<Producto>>(DatosLeidos);
        foreach (var UnProducto in ListaDeProductosDeserializada)
        {
            UnProducto.MostrarProducto();
        }
    }
}