using API.Dtos;

namespace ApiVeterinaria.Dtos;

public class EspecieMascotaDto
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public ICollection<MascotaDto> Mascotas { get; set; }
}
