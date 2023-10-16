using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class ClienteProductoConfiguration : IEntityTypeConfiguration<ClienteProducto>
{
    public void Configure(EntityTypeBuilder<ClienteProducto> builder)
    {
        builder.ToTable("clienteProducto");

    }
}
