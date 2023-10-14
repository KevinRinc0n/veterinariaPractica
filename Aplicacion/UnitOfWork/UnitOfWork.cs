using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiVeterinariaContext _context;
    private ICita _citas;

    public UnitOfWork(ApiVeterinariaContext context)
    {
        _context = context;
    }

    public ICita Citas
    {
        get
        {
            if (_citas == null)
            {
                _citas = new CitaRepository(_context);
            }
            return _citas;
        }
    }


    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
