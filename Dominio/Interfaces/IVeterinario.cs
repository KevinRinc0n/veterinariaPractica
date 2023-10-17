using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IVeterinario : IGenericRepository<Veterinario>
{
    Task<IEnumerable<Veterinario>> veterinarioCirujanoVascular();
}
