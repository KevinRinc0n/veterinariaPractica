using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
{
    public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
    {
        builder.ToTable("tratamientoMedico");

        builder.Property(c => c.Dosis)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.FechaAdministracion)
        .IsRequired();

        builder.Property(c => c.Observacion)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasData(
            new TratamientoMedico { Id = 1, Dosis = "33.3 mlg", FechaAdministracion = DateTime.Now, Observacion = "presenta contuciones"},
            new TratamientoMedico { Id = 2, Dosis = "2 tabletas", FechaAdministracion = DateTime.Now, Observacion = "una cada 12 horas"},
            new TratamientoMedico { Id = 3, Dosis = "123.9 mlg", FechaAdministracion = DateTime.Now, Observacion = "solo una inyeccion al dia"} 
        ); 
    }
}
