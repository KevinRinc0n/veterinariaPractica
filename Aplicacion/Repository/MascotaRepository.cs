using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class MascotaRepository : GenericRepository<Mascota>, IMascota
{
    private readonly ApiVeterinariaContext _context;

    public MascotaRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Mascota>> ObtenerMascotasFelinas()
    {
        var felinos = await _context.Mascotas
                    .Where(m => m.Raza.Especie.Nombre == "Felino")
                    .ToListAsync();

        return felinos;
    }

    public async Task<IEnumerable<Mascota>> mascotaVacunacion()
    {
        DateTime fecha = new DateTime(2023, 1, 1);
        DateTime fechaa = new DateTime(2023, 3, 31);

        var mascotasVacunadas = await _context.Mascotas
            .Where(m => m.Citas.Any(c => c.Motivo == "Vacunacion" && c.FechaCita >= fecha && c.FechaCita <= fechaa))
            .Include(m => m.Citas)
            .ToListAsync();

        return mascotasVacunadas;
    }

    public async Task<IEnumerable<Mascota>> mascotasAtendidasDetermiVeterinario(string NombreVeterinario)
    {
        var mascotasAtendidasVeterinario = await _context.Mascotas
            .Where(m => m.Citas.Any(c => c.Veterinario.Nombre == NombreVeterinario ))
            .Include(c => c.Citas)
            .ThenInclude(c => c.Veterinario)
            .ToListAsync();

        return mascotasAtendidasVeterinario;
    }

    public async Task<IEnumerable<Mascota>> mascotaGolden()
    {
        var mascotaGoldenRetriever = await _context.Mascotas
            .Where(m => m.Raza.Nombre == "Golden Retriver")
            .Include(c => c.Propietario)
            .ToListAsync();

        return mascotaGoldenRetriever;
    }
}