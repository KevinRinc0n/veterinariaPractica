using Dominio.Entities;

namespace ApiVeterinaria.Dtos;

public class EspecieDto
{
    public string Nombre { get; set; }
    public List<Mascota> Mascotas { get; set; }
}
