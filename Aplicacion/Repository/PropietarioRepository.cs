using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class PropietarioRepository : GenericRepository<Propietario>, IPropietario
{
    private readonly ApiVeterinariaContext _context;

    public PropietarioRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Propietario>> propietarioYMascotas()
    {
        var propietario =await _context.Propietarios
            .Include(u => u.Mascotas)
            .ToListAsync();

        return propietario;
    }
}