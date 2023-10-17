namespace ApiVeterinaria.Dtos;

public class MascotaAtendidaVeteDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<CitasDto> Citas { get; set; }
}
