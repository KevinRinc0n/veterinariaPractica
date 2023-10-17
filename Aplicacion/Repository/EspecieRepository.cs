using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;

public class EspecieRepository : GenericRepository<Especie>, IEspecie
{
    private readonly ApiVeterinariaContext _context;

    public EspecieRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> mascotaXEspecie()
    {
        var resultado = await _context.Especies
        .Include(e => e.Razas)
        .ThenInclude(r => r.Mascotas)
        .Select(especie => new
        {
            EspecieId = especie.Id,
            NombreEspecie = especie.Nombre,
            Razas = especie.Razas.Select(raza => new
            {
                RazaId = raza.Id,
                NombreRaza = raza.Nombre,
                Mascotas = raza.Mascotas.Select(mascota => new
                {
                    IdMascota = mascota.Id,
                    NombreMascota = mascota.Nombre,
                    FechaNacimiento = mascota.FechaNacimiento
                }).ToList()
            }).ToList()
        })
        .ToListAsync();

        return resultado;
    }
}