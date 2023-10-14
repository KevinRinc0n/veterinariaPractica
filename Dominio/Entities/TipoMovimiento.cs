namespace Dominio.Entities;

public class TipoMovimiento : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<MovimientoMedicamento> MovimientosMedicamentos { get; set; }
    public ICollection<MovimientoProducto> MovimientosProductos { get; set; }
}
