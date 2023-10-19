namespace ApiVeterinaria.Dtos;

public class MascotaGetDto
{
    public int Id { get; set; }
    public int IdPropietarioFk { get; set; }
    public int IdEspecieFk { get; set; }
    public int IdRazaFk { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
}
