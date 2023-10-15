namespace Aplicacion.Repository;

public class RazaRepository : GenericRepository<Raza>, IRaza
{
    private readonly ApiVeterinariaContext _context;

    public RazaRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}