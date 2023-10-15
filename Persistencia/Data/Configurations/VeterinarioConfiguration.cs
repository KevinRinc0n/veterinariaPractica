using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
{
    public void Configure(EntityTypeBuilder<Veterinario> builder)
    {
        builder.ToTable("veterinario");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Email)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Telefono)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Especialidad)
        .IsRequired()
        .HasMaxLength(50);
    }
}
