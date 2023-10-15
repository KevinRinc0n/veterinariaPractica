using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class ClientesProductos : IEntityTypeConfiguration<ClientesProductos>
{
    public void Configure(EntityTypeBuilder<ClientesProductos> builder)
    {
        builder.ToTable("clienteProducto");

    }
}
