namespace Models;

public class Proveedor
{
    public int Id { get; set; }
    public string Provincia { get; set; }
    public string Direccion { get; set; }
    public string NIF { get; set; }

    public Proveedor(string provincia, string direccion, string nif)
    {
        Provincia = provincia;
        Direccion = direccion;
        NIF = nif;
    }

    public Proveedor() { }
}
