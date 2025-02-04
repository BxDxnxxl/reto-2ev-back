namespace Models;

public class Comentario
{
    public int Id { get; set; }
    public int FkIdPelicula { get; set; }
    public int FkIdUsuario { get; set; }
    public int Valoracion { get; set; }
    public string ComentarioTexto { get; set; }

    public Comentario(int fkIdPelicula, int fkIdUsuario, int valoracion, string comentarioTexto)
    {
        FkIdPelicula = fkIdPelicula;
        FkIdUsuario = fkIdUsuario;
        Valoracion = valoracion;
        ComentarioTexto = comentarioTexto;
    }

    public Comentario() { }
}
