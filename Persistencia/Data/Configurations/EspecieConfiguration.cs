using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class EspecieConfiguration : IEntityTypeConfiguration<Especie>
{
    public void Configure(EntityTypeBuilder<Especie> builder)
    {
        builder.ToTable("especie");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50); 
    }
}
