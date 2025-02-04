namespace Models;

public class Sesion
{
    public int Id { get; set; }
    public int FkIdPelicula { get; set; }
    public int FkIdSala { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public Sesion(int fkIdPelicula, int fkIdSala, DateTime fechaInicio, DateTime fechaFin)
    {
        FkIdPelicula = fkIdPelicula;
        FkIdSala = fkIdSala;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
    }

    public Sesion() { }
}
