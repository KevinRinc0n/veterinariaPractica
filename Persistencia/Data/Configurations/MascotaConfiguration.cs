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

        builder.HasData(
            new Mascota { Id = 1, IdPropietarioFk = 1, IdEspecieFk = 1, IdRazaFk = 1, Nombre = "michi", FechaNacimiento = DateTime.Now},
            new Mascota { Id = 2, IdPropietarioFk = 1, IdEspecieFk = 1, IdRazaFk = 1, Nombre = "gato", FechaNacimiento =  DateTime.Now},
            new Mascota { Id = 3, IdPropietarioFk = 3, IdEspecieFk = 2, IdRazaFk = 1, Nombre = "firulais", FechaNacimiento =  DateTime.Now},
            new Mascota { Id = 4, IdPropietarioFk = 1, IdEspecieFk = 1, IdRazaFk = 1, Nombre = "gato con botas", FechaNacimiento =  DateTime.Now},
            new Mascota { Id = 5, IdPropietarioFk = 2, IdEspecieFk = 2, IdRazaFk = 2, Nombre = "tamara", FechaNacimiento =  DateTime.Now},
            new Mascota { Id = 6, IdPropietarioFk = 3, IdEspecieFk = 3, IdRazaFk = 3, Nombre = "terry", FechaNacimiento =   DateTime.Now},
            new Mascota { Id = 7, IdPropietarioFk = 3, IdEspecieFk = 4, IdRazaFk = 7, Nombre = "max", FechaNacimiento =   DateTime.Now},
            new Mascota { Id = 8, IdPropietarioFk = 1, IdEspecieFk = 4, IdRazaFk = 7, Nombre = "rokcy", FechaNacimiento =   DateTime.Now}
        );
    }
}
