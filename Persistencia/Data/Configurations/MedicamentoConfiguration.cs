using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable("medicamento");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Stock)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.Precio)
        .IsRequired()
        .HasColumnType("double");

        builder.Property(c => c.IdLaboratorioFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasMany(p => p.TratamientosMedicos)
        .WithMany(r => r.Medicamentos)
        .UsingEntity<TratamientoMedicamento>(
            
            j => j.HasOne(pt => pt.TratamientoMedico)
            .WithMany(t => t.TratamientosMedicamentos)
            .HasForeignKey(ut => ut.IdTratamientoFk),

            j => j.HasOne(et => et.Medicamento)
            .WithMany(et => et.TratamientosMedicamentos)
            .HasForeignKey(h => h.IdMedicamentoFk),

            j => 
            {
                j.HasKey(t => new { t.IdTratamientoFk, t.IdMedicamentoFk });
            }
        );

        builder.HasOne(c => c.Laboratorio)
        .WithMany(c => c.Medicamentos)
        .HasForeignKey(c => c.IdLaboratorioFk);
    }
}
