using System.ComponentModel.DataAnnotations;

namespace ApiVeterinaria.Dtos;

public class AddRoleDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Role { get; set; }
}
