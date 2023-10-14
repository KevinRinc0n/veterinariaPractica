namespace Dominio.Entities;

public class Producto : BaseEntity
{
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public double Precio { get; set; }
    public int IdProveedorFk { get; set; }
    public Proveedor Proveedor { get; set; }
    public ICollection<MovimientoProducto> MovimientosProductos { get; set; }
}
