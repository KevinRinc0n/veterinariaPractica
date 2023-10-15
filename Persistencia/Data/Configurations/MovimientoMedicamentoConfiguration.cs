using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
{
    public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
    {
        builder.ToTable("movimientoMedicamento");

        builder.Property(c => c.IdTipoMovimientoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdMedicamentoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.Cantidad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.CostoTotal)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.FechaMovimiento)
        .IsRequired();

        builder.HasOne(c => c.Medicamento)
        .WithMany(c => c.MovimientosMedicamentos)
        .HasForeignKey(c => c.IdMedicamentoFk);

        builder.HasOne(c => c.TipoMovimiento)
        .WithMany(c => c.MovimientosMedicamentos)
        .HasForeignKey(c => c.IdTipoMovimientoFk);
    }
}