using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class EspecieRepository : GenericRepository<Especie>, IEspecie
{
    private readonly ApiVeterinariaContext _context;

    public EspecieRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Especie>> mascotaXEspecie()
    {
        var mascotaXEspe = await _context.Especies
            .Include(m => m.Mascotas) 
            .ToListAsync();

        return mascotaXEspe;
    }
}