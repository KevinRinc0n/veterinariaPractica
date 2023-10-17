using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    private readonly ApiVeterinariaContext _context;

    public MedicamentoRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medicamento>> medicamentos5000()
    {
        var medicamentoCaros = await _context.Medicamentos
        .Where(m => m.Precio > 5000).ToListAsync();

        return medicamentoCaros;
    }

    public async Task<IEnumerable<Medicamento>> movimientoMedicamentos()
    {
        var movimientosMedic =await _context.Medicamentos
            .Include(u => u.MovimientosMedicamentos)
            .ToListAsync();

        return movimientosMedic;
    }
}