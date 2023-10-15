namespace Dominio.Entities;

public class User : BaseEntity
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Contraseña { get; set; }
    public ICollection<Rol> Roles { get; set; }
    public ICollection<UserRol> RolesUsuarios { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
}
