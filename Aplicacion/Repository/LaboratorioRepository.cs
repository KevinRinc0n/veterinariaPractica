using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class LaboratorioRepository : GenericRepository<Laboratorio>, ILaboratorio
{
    private readonly ApiVeterinariaContext _context;

    public LaboratorioRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}