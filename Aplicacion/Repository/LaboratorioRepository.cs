using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class LaboratorioRepository : GenericRepository<Laboratorio>, ILaboratorio
{
    private readonly ApiVeterinariaContext _context;

    public LaboratorioRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Laboratorio>> medicamentosGenfar()
    {
        var medicamentosLaboraGenfar = await _context.Laboratorios
            .Where(m => m.Nombre == "Genfar")
            .Include(m => m.Medicamentos) 
            .ToListAsync();

        return medicamentosLaboraGenfar;
    }
}