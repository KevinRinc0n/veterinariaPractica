namespace ApiVeterinaria.Dtos;

public class LaboratorioDeterMedicDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<Medicamento5000Dto> Medicamentos { get; set; }
}
