namespace ApiVeterinaria.Dtos;

public class TratamientoMedicoGetDto
{
    public int Id { get; set; }
    public string Dosis { get; set; } 
    public DateTime FechaAdministracion { get; set; }
    public string Observacion { get; set; }
}
