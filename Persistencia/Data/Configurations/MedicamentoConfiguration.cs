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

        builder.HasData(
            new Medicamento { Id = 1, Nombre = "Clonazepan", Stock = 34, Precio = 33.4, IdLaboratorioFk = 1},
            new Medicamento { Id = 2, Nombre = "Dolex", Stock = 2, Precio = 12.12, IdLaboratorioFk = 1},
            new Medicamento { Id = 3, Nombre = "Acetaminofen", Stock = 55, Precio = 1.54, IdLaboratorioFk = 1},
            new Medicamento { Id = 4, Nombre = "Jarabe para la tos", Stock = 1, Precio = 9.89, IdLaboratorioFk = 2},
            new Medicamento { Id = 5, Nombre = "Dolex Liquido", Stock = 98, Precio = 543.5, IdLaboratorioFk = 2},
            new Medicamento { Id = 6, Nombre = "Diclofenaco", Stock = 14, Precio = 6000, IdLaboratorioFk = 2},
            new Medicamento { Id = 7, Nombre = "Naproxeno", Stock = 31, Precio = 7000, IdLaboratorioFk = 2},
            new Medicamento { Id = 8, Nombre = "Loratadina ", Stock = 21, Precio = 5001, IdLaboratorioFk = 2},
            new Medicamento { Id = 9, Nombre = "Dolex", Stock = 4, Precio = 23.12, IdLaboratorioFk = 2},
            new Medicamento { Id = 10, Nombre = "Ramiprol", Stock = 97, Precio = 51000, IdLaboratorioFk = 2},
            new Medicamento { Id = 11, Nombre = "Aspirina", Stock = 1, Precio = 63000, IdLaboratorioFk = 2},
            new Medicamento { Id = 12, Nombre = "Lexotiroxina", Stock = 45, Precio = 87000, IdLaboratorioFk = 1}
        ); 
    }
}
