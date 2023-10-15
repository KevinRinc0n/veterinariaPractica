namespace Aplicacion.Repository;

public class TipoMovimientoRepository : GenericRepository<TipoMovimiento>, ITipoMovimiento
{
    private readonly ApiVeterinariaContext _context;

    public TipoMovimientoRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}