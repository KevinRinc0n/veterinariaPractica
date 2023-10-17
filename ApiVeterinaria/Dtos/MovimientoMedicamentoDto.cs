namespace ApiVeterinaria.Dtos;

public class MovimientoMedicamentoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<MedicamentoMovimientoDto> MovimientosMedicamentos { get; set; }
}
