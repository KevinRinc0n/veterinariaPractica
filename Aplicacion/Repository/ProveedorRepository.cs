namespace Aplicacion.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly ApiVeterinariaContext _context;

    public ProveedorRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}