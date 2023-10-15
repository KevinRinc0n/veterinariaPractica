using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class ClientesProductosRepository : GenericRepository<ClienteProducto>, IClientesProductos
{
    private readonly ApiVeterinariaContext _context;

    public ClientesProductosRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    } 
}
