using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class TratamientoMedicamentoConfiguration : IEntityTypeConfiguration<TratamientoMedicamento>
{
    public void Configure(EntityTypeBuilder<TratamientoMedicamento> builder)
    {
        builder.ToTable("tratamientoMedicamento");

        builder.Property(c => c.IdTratamientoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdMedicamentoFk)
        .IsRequired()
        .HasColumnType("int");
    }
}
