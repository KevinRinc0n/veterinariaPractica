using Dominio.Entities;

namespace ApiVeterinaria.Dtos;

public class RazaDto
{
    public string Nombre { get; set; }
    public List<Mascota> Mascotas { get; set; }
    
}
