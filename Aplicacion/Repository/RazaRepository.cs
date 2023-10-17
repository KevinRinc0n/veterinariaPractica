using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class RazaRepository : GenericRepository<Raza>, IRaza
{
    private readonly ApiVeterinariaContext _context;

    public RazaRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> mascotasPorRaza()
    {
        var mascotasXRaza = await _context.Razas
            .Select(raza => new
            {
                nombreRaza = raza.Nombre,
                mascotas = raza.Mascotas.Count
            })
            .ToListAsync();

        return mascotasXRaza;
    }
}