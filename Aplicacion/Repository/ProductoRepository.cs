using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly ApiVeterinariaContext _context;

    public ProductoRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}