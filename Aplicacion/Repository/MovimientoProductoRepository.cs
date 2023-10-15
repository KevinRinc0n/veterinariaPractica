namespace Aplicacion.Repository;

public class MovimientoProductoRepository : GenericRepository<MovimientoProducto>, IMovimientoProducto
{
    private readonly ApiVeterinariaContext _context;

    public MovimientoProductoRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}