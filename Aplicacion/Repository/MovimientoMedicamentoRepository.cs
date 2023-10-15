namespace Aplicacion.Repository;

public class MovimientoMedicamentoRepository : GenericRepository<MovimientoMedicamento>, IMovimientoMedicamento
{
    private readonly ApiVeterinariaContext _context;

    public MovimientoMedicamentoRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}