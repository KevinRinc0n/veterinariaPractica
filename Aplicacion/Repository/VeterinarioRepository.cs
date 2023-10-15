namespace Aplicacion.Repository;

public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinario
{
    private readonly ApiVeterinariaContext _context;

    public VeterinarioRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}