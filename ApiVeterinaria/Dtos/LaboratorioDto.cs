using Dominio.Entities;

namespace ApiVeterinaria.Dtos;

public class LaboratorioDto
{
    public string Nombre { get; set; }
    public List<Medicamento> Medicamentos { get; set; }
}
