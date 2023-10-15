using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class RazaRepository : GenericRepository<Raza>, IRaza
{
    private readonly ApiVeterinariaContext _context;

    public RazaRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}