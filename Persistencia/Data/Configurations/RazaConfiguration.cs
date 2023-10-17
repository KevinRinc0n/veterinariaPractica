using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class RazaConfiguration : IEntityTypeConfiguration<Raza>
{
    public void Configure(EntityTypeBuilder<Raza> builder)
    {
        builder.ToTable("raza");

        builder.Property(c => c.IdEspecieFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(c => c.Especie)
        .WithMany(c => c.Razas)
        .HasForeignKey(c => c.IdEspecieFk);

        builder.HasData(
            new Raza { Id = 1, IdEspecieFk = 1, Nombre = "gato"},
            new Raza { Id = 2, IdEspecieFk = 1, Nombre = "tigre"},
            new Raza { Id = 3, IdEspecieFk = 1, Nombre = "puma"},
            new Raza { Id = 4, IdEspecieFk = 2, Nombre = "rana"},
            new Raza { Id = 5, IdEspecieFk = 3, Nombre = "salamandra"},
            new Raza { Id = 6, IdEspecieFk = 3, Nombre = "cocodrilo"},
            new Raza { Id = 7, IdEspecieFk = 4, Nombre = "Golden Retriver"}
        );
    }
}