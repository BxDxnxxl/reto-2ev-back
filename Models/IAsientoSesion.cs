namespace Models;

public class AsientoSesion
{
    public int Id { get; set; }
    public int FkIdSesion { get; set; }
    public int FkIdAsiento { get; set; }
    public int? FkIdUsuario { get; set; }
    public DateTime? FechaReserva { get; set; }
    public bool Ocupado { get; set; }

    public AsientoSesion(int fkIdSesion, int fkIdAsiento, int? fkIdUsuario, DateTime? fechaReserva, bool ocupado)
    {
        FkIdSesion = fkIdSesion;
        FkIdAsiento = fkIdAsiento;
        FkIdUsuario = fkIdUsuario;
        FechaReserva = fechaReserva;
        Ocupado = ocupado;
    }

    public AsientoSesion() { }
}
