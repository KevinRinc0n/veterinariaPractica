namespace Dominio.Entities;

public class MovimientoMedicamento : BaseEntity
{
    public int IdTipoMovimientoFk { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }
    public int IdMedicamentoFk { get; set; }
    public Medicamento Medicamento { get; set; }
    public int Cantidad { get; set; }
    public string CostoTotal { get; set; }
    public DateTime FechaMovimiento { get; set; }
}
