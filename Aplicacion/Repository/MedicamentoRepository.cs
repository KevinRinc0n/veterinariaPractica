namespace Aplicacion.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    private readonly ApiVeterinariaContext _context;

    public MedicamentoRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}