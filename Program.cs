using System.Text.Json;
//Bienvenida
Funcion.GenerarTitulo("BIENVENIDO");
Console.WriteLine("Indexador de carpeta JSON:\n");

//Si quiero indexar alguna carpeta en particular, puedo darle la ruta directamente
//string RutaDeLaCarpeta = @"C:\Windows\System32\";
//string NombreDelArchivo = @"cmd.exe";
//string Ruta = RutaDeLaCarpeta + NombreDelArchivo;

// O puedo pedir la ruta
//string? RutaDeLaCarpeta = Console.ReadLine();
//string NombreDelArchivo = @"miArchivo.json";
//string Ruta = RutaDeLaCarpeta + NombreDelArchivo;

//También puedo trabajar con la ruta del proyecto
string RutaDeLaCarpeta = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
string NombreDelArchivo = @"\index.json";
string Ruta = RutaDeLaCarpeta + NombreDelArchivo;
Console.WriteLine("Indexando carpeta del proyecto [" + RutaDeLaCarpeta + "]");

//Control de archivo
if (!File.Exists(Ruta))
{
    Console.WriteLine("\nCreando archivo...");
    File.Create(Ruta);
    Console.WriteLine("Archivo creado.");
}

//FileStream
using (var FS = new FileStream(Ruta, FileMode.OpenOrCreate))
using (var SW = new StreamWriter(FS))
{
    var contador = 1;
    var ListaDeCarpetasASerializar = new List<Carpeta>();
    var ListaDeArchivosASerializar = new List<Archivo>();
    foreach (string Item in Directory.GetDirectories(RutaDeLaCarpeta))
    {
        var Elemento = new Carpeta(contador, new DirectoryInfo(Item).Name);
        ListaDeCarpetasASerializar.Add(Elemento);
        contador++;
    }
    foreach (string Item in Directory.GetFiles(RutaDeLaCarpeta))
    {
        var Elemento = new Archivo(contador, Path.GetFileNameWithoutExtension(Item), Path.GetExtension(Item));
        ListaDeArchivosASerializar.Add(Elemento);
        contador++;
    }
    string ListadoDeCarpetasSerealizado = JsonSerializer.Serialize(ListaDeCarpetasASerializar);
    string ListadoDeArchivosSelealizado = JsonSerializer.Serialize(ListaDeArchivosASerializar);
    SW.WriteLine(ListadoDeCarpetasSerealizado);
    SW.WriteLine(ListadoDeArchivosSelealizado);
    Console.WriteLine("\nListado creado correctamente. Revise la carpeta");
}