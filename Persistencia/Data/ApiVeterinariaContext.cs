using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;

public class ApiVeterinariaContext : DbContext
{
    public ApiVeterinariaContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Cita> Citas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<ClienteProducto> ClientesProductos { get; set; }
    public DbSet<Especie> Especies { get; set; }
    public DbSet<Laboratorio> Laboratorios { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<MovimientoMedicamento> MovimientosMedicamentos { get; set; }
    public DbSet<MovimientoProducto> MovimientosProductos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Propietario> Propietarios { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Raza> Razas { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<UserRol> RolesUsuarios { get; set; }
    public DbSet<TipoMovimiento> TiposMovimientos { get; set; }
    public DbSet<TratamientoMedicamento> TratamientosMedicamentos { get; set; }
    public DbSet<TratamientoMedico> TratamientosMedicos { get; set; }
    public DbSet<User> Usuarios { get; set; }
    public DbSet<Veterinario> Veterinarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
    }
}
