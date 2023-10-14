namespace Dominio.Entities;

public class Medicamento : BaseEntity
{
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public double Precio { get; set; }
    public int IdLaboratorioFk { get; set; }
    public Laboratorio Laboratorio { get; set; }
    public ICollection<MovimientoMedicamento> MovimientosMedicamentos { get; set; }
    public ICollection<TratamientoMedico> TratamientosMedicos { get; set; }
    public ICollection<TratamientoMedicamento> TratamientosMedicamentos { get; set; }
}
