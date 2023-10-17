using API.Dtos;
using Dominio.Entities;

namespace ApiVeterinaria.Dtos;

public class PropietarioDto
{   
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<MascotaDto> Mascotas { get; set; }
}
