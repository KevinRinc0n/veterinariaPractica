using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class TratamientoMedicoRepository : GenericRepository<TratamientoMedico>, ITratamientoMedico
{
    private readonly ApiVeterinariaContext _context;

    public TratamientoMedicoRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}