namespace Dominio.Entities;

public class Raza
{
    public int IdEspecieFk { get; set; }
    public Especie Especie { get; set; }
    public string Nombre { get; set; }
    public ICollection<Mascota> Mascotas { get; set; }
}
