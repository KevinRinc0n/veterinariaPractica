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

        DateTime fechaCita1 = new DateTime(2023, 2, 2);
        DateTime fechaCita2 = new DateTime(2023, 1, 4);

        builder.HasData(
            new Cita { Id = 1, IdTratamientoFk = 3, IdMascotaFk = 1, IdVeterinarioFk = 4, FechaCita = fechaCita1, HoraCita = DateTime.Now.TimeOfDay, Motivo = "Vacunacion" },
            new Cita { Id = 2, IdTratamientoFk = 1, IdMascotaFk = 4, IdVeterinarioFk = 5, FechaCita = fechaCita2, HoraCita = DateTime.Now.TimeOfDay, Motivo = "Vacunacion" },
            new Cita { Id = 3, IdTratamientoFk = 2, IdMascotaFk = 3, IdVeterinarioFk = 1, FechaCita = fechaCita1, HoraCita = DateTime.Now.TimeOfDay, Motivo = "Revision general"},
            new Cita { Id = 4, IdTratamientoFk = 3, IdMascotaFk = 2, IdVeterinarioFk = 4, FechaCita = fechaCita2, HoraCita = DateTime.Now.TimeOfDay, Motivo = "Vacunacion"}
        );
    }
}
