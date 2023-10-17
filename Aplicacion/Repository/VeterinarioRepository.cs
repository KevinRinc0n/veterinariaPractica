using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinario
{
    private readonly ApiVeterinariaContext _context;

    public VeterinarioRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Veterinario>> veterinarioCirujanoVascular()
    {
        var veterinarioVascular = await _context.Veterinarios
            .Where(v => v.Especialidad == "cirujano vascular").ToListAsync();

        return veterinarioVascular;
    }
}