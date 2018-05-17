using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome);
            builder.Property(p => p.Email);
            builder.Property(p => p.Foto);
            builder.Property(p => p.AssinaturaAlteracao);
            builder.Ignore(p => p.File);
            builder.HasMany<Pedido>(c => c.Pedidos).WithOne(p => p.Cliente).HasForeignKey("IdCliente");
        }
    }
}
