using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IProveedor : IGenericRepository<Proveedor>
{
    Task<IEnumerable<Laboratorio>> proveedorMedicaDeterminado(string NombreMedicamento);
}
