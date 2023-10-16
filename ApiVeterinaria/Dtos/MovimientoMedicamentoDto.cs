namespace ApiVeterinaria.Dtos;

public class MovimientoMedicamentoDto
{
    public int IdTipoMovimientoFk { get; set; }
    public int IdMedicamentoFk { get; set; }
    public int Cantidad { get; set; }
    public string CostoTotal { get; set; }
}
