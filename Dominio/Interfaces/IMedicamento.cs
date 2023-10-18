using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IMedicamento : IGenericRepository<Medicamento>
{
    Task<IEnumerable<Medicamento>> medicamentos50000();
    Task<IEnumerable<Medicamento>> movimientoMedicamentos();
}
