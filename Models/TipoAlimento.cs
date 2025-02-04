namespace Models;

public class TipoAlimento
{
    public int Id { get; set; }
    public string Tipo { get; set; }

    public TipoAlimento(string tipo)
    {
        Tipo = tipo;
    }

    public TipoAlimento() { }
}
