namespace Aplicacion.Repository;

public class CitaRepository : GenericRepository<Cita>, ICita
{
    private readonly ApiVeterinariaContext _context;

    public CitaRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}
