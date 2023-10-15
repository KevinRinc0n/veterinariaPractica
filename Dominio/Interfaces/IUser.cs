using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IUser : IGeneric<User>
{
    Task<User> GetByUsernameAsync(string username);
    Task<User> GetByRefreshTokenAsync(string username);
}
