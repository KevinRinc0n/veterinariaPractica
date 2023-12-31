namespace ApiVeterinaria.Dtos;

public class MedicamentoLaboDto
{
    public int Id {get; set;}
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public ICollection<laboMedicamentoDto> Medicamentos { get; set; }
}