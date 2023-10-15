namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    ICita Citas { get; }
    ICliente Clientes { get; }
    IClientesProductos ClientesProductos { get; }
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
    IUsersRols RolesUsuarios { get; }
    ITipoMovimiento TiposMovimientos { get; }
    ITratamientoMedicamento TratamientoMedicamentos { get; }
    ITratamientoMedico TratamientosMedicos { get; }
    IUser Usuarios { get; }
    IVeterinario Veterinarios { get; }


    Task<int> SaveAsync();
}
