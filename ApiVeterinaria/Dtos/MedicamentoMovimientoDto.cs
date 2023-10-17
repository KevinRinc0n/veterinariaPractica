namespace ApiVeterinaria.Dtos;

public class MedicamentoMovimientoDto
{
    public int Id { get; set; }
    public int IdTipoMovimientoFk { get; set; }
    public string CostoTotal { get; set; }
}
