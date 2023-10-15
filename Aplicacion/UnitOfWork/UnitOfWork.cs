using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiVeterinariaContext _context;
    private ICita _citas;
    private ICliente _clientes;
    private IEspecie _especies;
    private ILaboratorio _laboratorios;
    private IMascota _mascotas;
    private IMedicamento _medicamentos;
    private IMovimientoMedicamento _movimientosMedicamentos;
    private IMovimientoProducto _movimientosProductos;
    private IProducto _productos;
    private IPropietario _propietarios;
    private IProveedor _proveedor;
    private IRaza _razas;
    private IRol _roles;
    private IUsersRols _rolesUsuarios;
    private ITipoMovimiento _tiposMovimientos;
    private ITratamientoMedicamento _tratamientosMedicamentos;
    private ITratamientoMedico _tratamientosMedicos;
    private IUser _usuarios;
    private IVeterinario _veterinarios;


    public UnitOfWork(ApiVeterinariaContext context)
    {
        _context = context;
    }

    public ICita Citas
    {
        get
        {
            if (_citas == null)
            {
                _citas = new CitaRepository(_context);
            }
            return _citas;
        }
    }

    public ICliente Clientes
    {
        get
        {
            if (_clientes == null)
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }

    public IEspecie Especies
    {
        get
        {
            if (_especies == null)
            {
                _especies = new EspecieRepository(_context);
            }
            return _especies;
        }
    }

    public ILaboratorio Laboratorios
    {
        get
        {
            if (_laboratorios == null)
            {
                _laboratorios = new LaboratorioRepository(_context);
            }
            return _laboratorios;
        }
    }

    public IMascota Mascotas
    {
        get
        {
            if (_mascotas == null)
            {
                _mascotas = new MascotaRepository(_context);
            }
            return _mascotas;
        }
    }

    public IMedicamento Medicamentos
    {
        get
        {
            if (_medicamentos == null)
            {
                _medicamentos = new MedicamentoRepository(_context);
            }
            return _medicamentos;
        }
    }

    public IMovimientoMedicamento MovimientoMedicamentos
    {
        get
        {
            if (_movimientosMedicamentos == null)
            {
                _movimientosMedicamentos = new MovimientoMedicamentoRepository(_context);
            }
            return _movimientosMedicamentos;
        }
    }

    public IMovimientoProducto MovimientoProductos
    {
        get
        {
            if (_movimientosProductos == null)
            {
                _movimientosProductos = new MovimientoProductoRepository(_context);
            }
            return _movimientosProductos;
        }
    }

    public IProducto Productos
    {
        get
        {
            if (_productos == null)
            {
                _productos = new ProductoRepository(_context);
            }
            return _productos;
        }
    }

    public IPropietario Propietarios
    {
        get
        {
            if (_propietarios == null)
            {
                _propietarios = new PropietarioRepository(_context);
            }
            return _propietarios;
        }
    }

    public IProveedor Proveedores
    {
        get
        {
            if (_proveedor == null)
            {
                _proveedor = new ProveedorRepository(_context);
            }
            return _proveedor;
        }
    }
    
    public IRaza Razas
    {
        get
        {
            if (_razas == null)
            {
                _razas = new RazaRepository(_context);
            }
            return _razas;
        }
    }

    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUsersRols RolesUsuarios
    {
        get
        {
            if (_rolesUsuarios == null)
            {
                _rolesUsuarios = new UsersRolsRepository(_context);
            }
            return _rolesUsuarios;
        }
    }

    public ITipoMovimiento TiposMovimientos
    {
        get
        {
            if (_tiposMovimientos == null)
            {
                _tiposMovimientos = new TipoMovimientoRepository(_context);
            }
            return _tiposMovimientos;
        }
    }

    public ITratamientoMedicamento TratamientoMedicamentos
    {
        get
        {
            if (_tratamientosMedicamentos == null)
            {
                _tratamientosMedicamentos = new TratamientoMedicamentoRepository(_context);
            }
            return _tratamientosMedicamentos;
        }
    }

    public ITratamientoMedico TratamientosMedicos
    {
        get
        {
            if (_tratamientosMedicos == null)
            {
                _tratamientosMedicos = new TratamientoMedicoRepository(_context);
            }
            return _tratamientosMedicos;
        }
    }

    public IUser Usuarios
    {
        get
        {
            if (_usuarios == null)
            {
                _usuarios = new UserRepository(_context);
            }
            return _usuarios;
        }
    }

    public IVeterinario Veterinarios 
    {
        get
        {
            if (_veterinarios == null)
            {
                _veterinarios = new VeterinarioRepository(_context);
            }
            return _veterinarios;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
