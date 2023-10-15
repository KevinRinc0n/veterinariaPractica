namespace Dominio.Entities;

public class Rol : BaseEntity
{
    public string Nombre { get; set; }
    public ICollection<User> Usuarios { get; set; }
    public ICollection<UsersRols> RolesUsuarios { get; set; }
}
