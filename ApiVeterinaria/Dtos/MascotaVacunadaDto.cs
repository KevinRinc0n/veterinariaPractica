namespace ApiVeterinaria.Dtos;

public class MascotaVacunadaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<CitaDto> Citas { get; set; }
}
