using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class PropietarioRepository : GenericRepository<Propietario>, IPropietario
{
    private readonly ApiVeterinariaContext _context;

    public PropietarioRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}