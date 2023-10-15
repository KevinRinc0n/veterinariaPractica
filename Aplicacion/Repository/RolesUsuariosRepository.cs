using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class RolesUsuariosRepository : GenericRepository<RolesUsuarios>, IRolesUsuarios
{
    private readonly ApiVeterinariaContext _context;

    public RolesUsuariosRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}