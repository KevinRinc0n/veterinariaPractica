namespace Dominio.Entities;
public class TratamientoMedicamento : BaseEntity
{
    public int IdTratamientoFk { get; set; }
    public TratamientoMedico TratamientoMedico { get; set; }
    public int IdMedicamentoFk { get; set; }
    public Medicamento Medicamento { get; set; }
}