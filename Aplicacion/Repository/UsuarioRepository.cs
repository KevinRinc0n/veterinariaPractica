using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    private readonly ApiVeterinariaContext _context;

    public UsuarioRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}