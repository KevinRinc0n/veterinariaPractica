namespace Dominio.Entities;

public class UsersRols : BaseEntity
{
    public int IdUsuarioFk { get; set; }
    public User Usuario { get; set; }
    public int IdRolFk { get; set; }
    public Rol Rol { get; set; }
}
