using ApiVeterinaria.Dtos;

namespace API.Dtos;

public class MascotaDto
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public DateTime FechaNacimiento {get; set;}
}