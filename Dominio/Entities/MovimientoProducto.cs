namespace Dominio.Entities;

public class MovimientoProducto : BaseEntity
{
    public int IdTipoMovimientoFk { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }
    public int IdProductoFk { get; set; }
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }
    public string CostoTotal { get; set; }
    public DateTime FechaMovimiento { get; set; }
}
