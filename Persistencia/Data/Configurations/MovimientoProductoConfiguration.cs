using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class MovimientoProductoConfiguration : IEntityTypeConfiguration<MovimientoProducto>
{
    public void Configure(EntityTypeBuilder<MovimientoProducto> builder)
    {
        builder.ToTable("movimientoProducto");

        builder.Property(c => c.IdTipoMovimientoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdProductoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.Cantidad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.CostoTotal)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.FechaMovimiento)
        .IsRequired();

        builder.HasOne(c => c.Producto)
        .WithMany(c => c.MovimientosProductos)
        .HasForeignKey(c => c.IdProductoFk);

        builder.HasOne(c => c.TipoMovimiento)
        .WithMany(c => c.MovimientosProductos)
        .HasForeignKey(c => c.IdTipoMovimientoFk);
    }
}
