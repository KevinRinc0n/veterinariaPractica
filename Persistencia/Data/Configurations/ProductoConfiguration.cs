using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("producto");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Stock)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.Precio)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(c => c.IdProveedorFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(c => c.Proveedor)
        .WithMany(c => c.Productos)
        .HasForeignKey(c => c.IdProveedorFk);
    }
}
