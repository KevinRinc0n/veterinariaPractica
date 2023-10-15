namespace Dominio.Entities;

public class Cliente : BaseEntity
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public ICollection<Producto> Productos { get; set; }
    public ICollection<ClienteProducto> ClientesProductos { get; set; }
}
