namespace Aplicacion.Repository;

public class TratamientoMedicamentoRepository : GenericRepository<TratamientoMedicamento>, ITratamientoMedicamento
{
    private readonly ApiVeterinariaContext _context;

    public TratamientoMedicamentoRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}