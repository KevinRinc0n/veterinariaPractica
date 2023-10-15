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
    }
}
