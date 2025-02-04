namespace Models;

public class Asiento
{
    public int Id { get; set; }
    public int FkIdSala { get; set; }
    public int Fila { get; set; }
    public int Numero { get; set; }

    public Asiento(int fkIdSala, int fila, int numero)
    {
        FkIdSala = fkIdSala;
        Fila = fila;
        Numero = numero;
    }

    public Asiento() { }
}
