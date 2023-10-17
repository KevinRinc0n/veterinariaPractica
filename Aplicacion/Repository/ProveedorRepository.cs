using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly ApiVeterinariaContext _context;

    public ProveedorRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Laboratorio>> proveedorMedicaDeterminado(string NombreMedicamento)
    {
        var medicamentoProveedor = await _context.Laboratorios
            .Where(m => m.Medicamentos.Any(c => c.Nombre == NombreMedicamento ))
            .Include(c => c.Medicamentos)
            .ToListAsync();

        return medicamentoProveedor;
    }
}