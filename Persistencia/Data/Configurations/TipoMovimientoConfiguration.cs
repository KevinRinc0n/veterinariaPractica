using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimiento>
{
    public void Configure(EntityTypeBuilder<TipoMovimiento> builder)
    {
        builder.ToTable("tipoMovimiento");

        builder.Property(c => c.Descripcion)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasData(
            new TipoMovimiento { Id = 1, Descripcion = "Venta"},
            new TipoMovimiento { Id = 2, Descripcion = "Compra"}
        );
    }
}
