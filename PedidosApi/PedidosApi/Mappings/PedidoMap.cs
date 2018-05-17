using Microsoft.EntityFrameworkCore;
using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedido");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Data);
            builder.Property(p => p.Numero);
            builder.HasOne(p => p.Cliente).WithMany(p => p.Pedidos).HasForeignKey(p => p.IdCliente).HasConstraintName("IdCliente");
        }
    }
}
