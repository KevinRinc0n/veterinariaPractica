namespace Aplicacion.Repository;

public class LaboratorioRepository : GenericRepository<Laboratorio>, ILaboratorio
{
    private readonly ApiVeterinariaContext _context;

    public LaboratorioRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}