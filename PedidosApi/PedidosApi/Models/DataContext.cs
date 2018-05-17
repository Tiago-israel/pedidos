using Microsoft.EntityFrameworkCore;
using PedidosApi.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoItem> PedidosItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            //modelBuilder.Entity<Pedido>().HasOne<Cliente>(p => p.Cliente).WithMany(c => c.Pedidos).HasForeignKey(p => p.IdCliente).HasConstraintName("IdCliente");
            //modelBuilder.Entity<Cliente>().HasMany<Pedido>(c => c.Pedidos).WithOne(p => p.Cliente).HasForeignKey("IdCliente");
        }
    }
}

