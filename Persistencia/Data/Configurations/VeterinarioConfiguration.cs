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

        builder.HasData(
            new Veterinario { Id = 1, Nombre = "maria", Email = "maria@gmail.com", Telefono = "1234", Especialidad = "cirujano vascular" },
            new Veterinario { Id = 2, Nombre = "jose", Email = "jose@gmail.com", Telefono = "1234567", Especialidad = "castrador" },
            new Veterinario { Id = 3, Nombre = "saul", Email = "saul@gmail.com", Telefono = "1234444", Especialidad = "cirujano vascular"},
            new Veterinario { Id = 4, Nombre = "paco", Email = "paco@gmail.com", Telefono = "5454", Especialidad = "vacunador" },
            new Veterinario { Id = 5, Nombre = "valentina", Email = "valentina@gmail.com", Telefono = "7644", Especialidad = "revisiones generales" }
        );
    }
}
