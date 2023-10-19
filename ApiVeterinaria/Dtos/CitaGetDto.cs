namespace ApiVeterinaria.Dtos;

public class CitaGetDto
{
    public int Id { get; set; }
    public int IdTratamientoFk { get; set; }
    public int IdMascotaFk { get; set; }
    public DateTime FechaCita { get; set; }
    public TimeSpan HoraCita  { get; set; }
    public string Motivo { get; set; } 
    public int IdVeterinarioFk { get; set; }
}
