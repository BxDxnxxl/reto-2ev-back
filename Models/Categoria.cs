namespace Models;

public class Categoria
{
    public int Id { get; set; }
    public string Tipo { get; set; }

    public Categoria(string tipo)
    {
        Tipo = tipo;
    }

    public Categoria() { }
}
