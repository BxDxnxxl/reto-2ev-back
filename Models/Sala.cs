namespace Models;

public class Sala
{
    public int Id { get; set; }
    public int Capacidad { get; set; }
    public string Nombre { get; set; }

    public Sala(int capacidad, string nombre)
    {
        Capacidad = capacidad;
        Nombre = nombre;
    }

    public Sala() { }
}
