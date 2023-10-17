using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IEspecie : IGenericRepository<Especie>
{
    Task<IEnumerable<object>> mascotaXEspecie();
}
