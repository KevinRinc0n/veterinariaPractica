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
    }
}