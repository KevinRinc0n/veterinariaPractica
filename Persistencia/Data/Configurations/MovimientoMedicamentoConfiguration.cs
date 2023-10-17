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

        builder.HasData(
            new MovimientoMedicamento { Id = 1, IdMedicamentoFk = 1, IdTipoMovimientoFk = 1, Cantidad = 3, CostoTotal = "33.3", FechaMovimiento = DateTime.Now},
            new MovimientoMedicamento { Id = 2, IdMedicamentoFk = 1, IdTipoMovimientoFk = 2, Cantidad = 1, CostoTotal = "65.3", FechaMovimiento = DateTime.Now},
            new MovimientoMedicamento { Id = 3, IdMedicamentoFk = 2, IdTipoMovimientoFk = 2, Cantidad = 2, CostoTotal = "7000", FechaMovimiento = DateTime.Now},
            new MovimientoMedicamento { Id = 4, IdMedicamentoFk = 3, IdTipoMovimientoFk = 1, Cantidad = 3, CostoTotal = "6546.8", FechaMovimiento = DateTime.Now},
            new MovimientoMedicamento { Id = 5, IdMedicamentoFk = 2, IdTipoMovimientoFk = 2, Cantidad = 3, CostoTotal = "2500", FechaMovimiento = DateTime.Now}
        );
    }
}