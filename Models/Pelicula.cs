namespace Models;

public class Pelicula {

    public int Id  {get;set;}
    public string Nombre {get;set;}
    public string Descripcion {get;set;} 
    public string Director {get;set;}
    public DateTime AnioSalida {get; set;}  
    public string ImagenBannerUrl {get;set;}
    public string ImagenPequeniaUrl {get;set;}
    public int Duracion  {get;set;}
    public double Precio {get;set;}

    public Pelicula(string nombre, string descripcion, string director, DateTime anioSalida, string imagenBannerUrl, string imagenPequeniaUrl, int duracion, double precio) {
        Nombre = nombre;
        Descripcion = descripcion;
        Director = director;
        AnioSalida = anioSalida;
        ImagenBannerUrl = imagenBannerUrl;
        ImagenPequeniaUrl = imagenPequeniaUrl;
        Duracion = duracion;
        Precio = precio;
    }
    public Pelicula(){}

}
