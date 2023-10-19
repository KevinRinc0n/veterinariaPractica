namespace ApiVeterinaria.Dtos;

public class MedicamentoGetDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public double Precio { get; set; }
    public int IdLaboratorioFk { get; set; }
}
