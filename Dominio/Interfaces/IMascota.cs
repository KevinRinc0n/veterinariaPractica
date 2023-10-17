using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IMascota : IGenericRepository<Mascota>
{
    Task<IEnumerable<Mascota>> ObtenerMascotasFelinas();
    Task<IEnumerable<Mascota>> mascotaVacunacion();
    Task<IEnumerable<Mascota>> mascotasAtendidasDetermiVeterinario(string NombreVeterinario);
    Task<IEnumerable<Mascota>> mascotaGolden();
}
