namespace Models;

public class Usuario
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Nombre { get; set; }
    public string Apellido1 { get; set; }
    public string Apellido2 { get; set; }
    public string Contraseña { get; set; }
    public string ProfilePic { get; set; }

    public Usuario(string username, string nombre, string apellido1, string apellido2, string contraseña, string profilePic)
    {
        Username = username;
        Nombre = nombre;
        Apellido1 = apellido1;
        Apellido2 = apellido2;
        Contraseña = contraseña;
        ProfilePic = profilePic;
    }

    public Usuario() { }
}
