using Dominio.Entities;

namespace ApiVeterinaria.Dtos;

public class PropietarioDto
{
    public string Nombre { get; set; }
    public List<Mascota> Mascotas { get; set; }
}
