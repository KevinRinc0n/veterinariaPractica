using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ToTable("cita");

        builder.Property(c => c.IdTratamientoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdMascotaFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdVeterinarioFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.FechaCita)
        .IsRequired();

        builder.Property(c => c.HoraCita)
        .IsRequired();

        builder.Property(c => c.Motivo)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(c => c.TratamientoMedico)
        .WithMany(c => c.Citas)
        .HasForeignKey(c => c.IdTratamientoFk);

        builder.HasOne(c => c.Mascota)
        .WithMany(c => c.Citas)
        .HasForeignKey(c => c.IdMascotaFk);

        builder.HasOne(c => c.Veterinario)
        .WithMany(c => c.Citas)
        .HasForeignKey(c => c.IdVeterinarioFk);
    }
}
