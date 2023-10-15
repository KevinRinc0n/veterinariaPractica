namespace Dominio.Entities;

public class ClienteProducto : BaseEntity
{
    public int IdClienteFk {get; set; }
    public Cliente Cliente { get; set; }
    public int IdProductoFk {get; set; }
    public Producto Producto { get; set; }
}
