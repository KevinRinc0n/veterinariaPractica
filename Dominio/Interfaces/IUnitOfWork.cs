namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    ICIta Citas { get; }
    ICliente Clientes { get; }
    IEspecie Especies { get; }
    ILaboratorio Laboratorios { get; }
    IMascota Mascotas { get; }
    IMedicamento Medicamentos { get; }
    IMovimientoMedicamento MovimientosMedicamentos { get; }
    IMovimientoProducto MovimientosProductos { get; }
    IProducto Productos { get; }
    IPropietario Propietarios { get; }
    IProveedor Proveedores { get; }
    IRaza Razas { get; }
    IRol Roles { get; }
    IRolesUsuarios RolesUsuarios { get; }
    ITipoMovimiento TiposMovimientos { get; }
    ITratamientoMedicamento TratamientoMedicamentos { get; }
    ITratamientoMedico TratamientosMedicos { get; }
    IUsuario Usuarios { get; }
    IVeterinario veterinarios { get; }


    Task<int> SaveAsync();
}
