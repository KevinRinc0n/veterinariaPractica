using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class EspecieConfiguration : IEntityTypeConfiguration<Especie>
{
    public void Configure(EntityTypeBuilder<Especie> builder)
    {
        builder.ToTable("especie");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50); 

        builder.HasData(
            new Especie { Id = 1, Nombre = "Felino"},
            new Especie { Id = 2, Nombre = "Anfibio"},
            new Especie { Id = 3, Nombre = "Reptil"},
            new Especie { Id = 4, Nombre = "Canino"}
        );
    }
}
