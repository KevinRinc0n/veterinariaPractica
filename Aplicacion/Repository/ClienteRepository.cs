namespace Aplicacion.Repository;

public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly ApiVeterinariaContext _context;

    public ClienteRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}