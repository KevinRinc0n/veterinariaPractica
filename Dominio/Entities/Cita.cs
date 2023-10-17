namespace Dominio.Entities;

public class Cita : BaseEntity
{
    public int IdTratamientoFk { get; set; }
    public TratamientoMedico TratamientoMedico { get; set; }
    public int IdMascotaFk { get; set; }
    public Mascota Mascota { get; set; }
    public DateTime FechaCita { get; set; }
    public TimeSpan HoraCita  { get; set; }
    public string Motivo { get; set; } 
    public int IdVeterinarioFk { get; set; }
    public Veterinario Veterinario { get; set; }
}
