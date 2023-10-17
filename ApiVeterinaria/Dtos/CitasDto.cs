namespace ApiVeterinaria.Dtos;

public class CitasDto
{
    public int Id { get; set; }
    public DateTime FechaCita { get; set; }
    public TimeSpan HoraCita  { get; set; }
    public int IdVeterinarioFk { get; set; }
    public VeterinarioDto Veterinario { get; set; }
}
