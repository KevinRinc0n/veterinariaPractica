namespace Aplicacion.Repository;

public class MascotaRepository : GenericRepository<Mascota>, IMascota
{
    private readonly ApiVeterinariaContext _context;

    public MascotaRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}