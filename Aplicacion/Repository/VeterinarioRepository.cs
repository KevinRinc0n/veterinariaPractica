using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinario
{
    private readonly ApiVeterinariaContext _context;

    public VeterinarioRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}