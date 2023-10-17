namespace ApiVeterinaria.Dtos;

public class MascotaPropietarioDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public PropietarioMascotaDto Propietario { get; set; }
}
