using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario>
{
    public void Configure(EntityTypeBuilder<Propietario> builder)
    {
        builder.ToTable("propietario");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Email)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Telefono)
        .IsRequired()
        .HasMaxLength(50);
    }
}