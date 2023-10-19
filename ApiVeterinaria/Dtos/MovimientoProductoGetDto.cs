namespace ApiVeterinaria.Dtos;

public class MovimientoProductoGetDto
{
    public int Id { get; set; }
    public int IdTipoMovimientoFk { get; set; }
    public int IdProductoFk { get; set; }
    public int Cantidad { get; set; }
    public string CostoTotal { get; set; }
    public DateTime FechaMovimiento { get; set; }
}
