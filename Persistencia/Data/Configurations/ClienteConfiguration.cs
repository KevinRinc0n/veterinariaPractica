using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.Telefono)
        .IsRequired()
        .HasMaxLength(50);

         builder.HasMany(p => p.Productos)
            .WithMany(r => r.Clientes)
            .UsingEntity<ClienteProducto>(
                
                j => j.HasOne(pt => pt.Producto)
                .WithMany(t => t.ClientesProductos)
                .HasForeignKey(ut => ut.IdProductoFk),

                j => j.HasOne(et => et.Cliente)
                .WithMany(et => et.ClientesProductos)
                .HasForeignKey(h => h.IdClienteFk),

                j => 
                {
                    j.HasKey(t => new { t.IdClienteFk, t.IdProductoFk });
                }
            );
    }
}
