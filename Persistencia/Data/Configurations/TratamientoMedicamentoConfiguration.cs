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

        builder.HasData(
            new TratamientoMedicamento { Id = 1, IdMedicamentoFk = 5, IdTratamientoFk = 1},
            new TratamientoMedicamento { Id = 2, IdMedicamentoFk = 2, IdTratamientoFk = 2},
            new TratamientoMedicamento { Id = 3, IdMedicamentoFk = 4, IdTratamientoFk = 3}
        );
    }
}
