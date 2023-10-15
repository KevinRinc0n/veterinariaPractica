using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly ApiVeterinariaContext _context;

    public RolRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}