using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
{
    public void Configure(EntityTypeBuilder<Mascota> builder)
    {
        builder.ToTable("mascota");

        builder.Property(c => c.IdPropietarioFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdEspecieFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdRazaFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.FechaNacimiento)
        .IsRequired();

        builder.HasOne(c => c.Especie)
        .WithMany(c => c.Mascotas)
        .HasForeignKey(c => c.IdEspecieFk);

        builder.HasOne(c => c.Propietario)
        .WithMany(c => c.Mascotas)
        .HasForeignKey(c => c.IdPropietarioFk);

        builder.HasOne(c => c.Raza)
        .WithMany(c => c.Mascotas)
        .HasForeignKey(c => c.IdRazaFk);
    }
}
