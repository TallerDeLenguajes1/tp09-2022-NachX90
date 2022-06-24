public class Carpeta
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public Carpeta(int id, string nombre)
    {
        ID = id;
        Nombre = nombre;
    }
}

public class Archivo
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Extension { get; set; }
    public Archivo(int id, string nombre, string extension)
    {
        ID = id;
        Nombre = nombre;
        Extension = extension;
    }
}