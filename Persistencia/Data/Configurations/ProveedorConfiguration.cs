using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("proveedor");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Direccion)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Telefono)
        .IsRequired()
        .HasMaxLength(50);
    }
}
