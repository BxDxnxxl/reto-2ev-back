namespace Models;

public class Comida
{
    public int Id { get; set; }
    public int FkIdTipoAlimento { get; set; }
    public string Nombre { get; set; }

    public Comida(int fkIdTipoAlimento, string nombre)
    {
        FkIdTipoAlimento = fkIdTipoAlimento;
        Nombre = nombre;
    }

    public Comida() { }
}
