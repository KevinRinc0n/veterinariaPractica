namespace Dominio.Entities;

public class TratamientoMedico : BaseEntity
{
    public string Dosis { get; set; } 
    public DateTime FechaAdministracion { get; set; }
    public string Observacion { get; set; }
    public ICollection<Cita> Citas { get; set; }
    public ICollection<Medicamento> Medicamentos { get; set; }
    public ICollection<TratamientoMedicamento> TratamientosMedicamentos { get; set; }
}
