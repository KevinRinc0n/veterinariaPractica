using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly ApiVeterinariaContext _context;

    public ClienteRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}