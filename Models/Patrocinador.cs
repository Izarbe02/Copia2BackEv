using System;
using Models;

public class Patrocinador
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Logo { get; set; }
    public string Contacto { get; set; }
    public int IdOrganizador { get; set; }

    public Patrocinador(string nombre, string descripcion, string logo, string contacto, int idOrganizador)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Logo = logo;
        Contacto = contacto;
        IdOrganizador = idOrganizador;
    }

    public Patrocinador() { }
}
