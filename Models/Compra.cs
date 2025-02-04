namespace Models;

public class Compra
{
    public int Id { get; set; }
    public int FkIdUsuario { get; set; }

    public Compra(int fkIdUsuario)
    {
        FkIdUsuario = fkIdUsuario;
    }

    public Compra() { }
}
