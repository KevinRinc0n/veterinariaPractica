namespace Aplicacion.Repository;

public class EspecieRepository : GenericRepository<Especie>, IEspecie
{
    private readonly ApiVeterinariaContext _context;

    public EspecieRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}