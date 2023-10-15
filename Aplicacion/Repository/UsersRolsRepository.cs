using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class UsersRolsRepository : GenericRepository<UsersRols>, IUsersRols
{
    private readonly ApiVeterinariaContext _context;

    public UsersRolsRepository(ApiVeterinariaContext context) : base(context)
    {
        _context = context;
    }
}