namespace ApiVeterinaria.Dtos;

public class CitaDto
{
    public int IdMascotaFk { get; set; }
    public string Motivo { get; set; }
    public DateTime FechaCita { get; set; }
    public TimeSpan HoraCita  { get; set; }
}
