using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDePedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDePedidos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}
        public DbSet<Pedido> PedidosBD {get; set;}
        public DbSet<Pedido> ItensPedidosBD {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.Entity<ItemPedido>() 
                .HasOne(i => i.Pedido) 
                .WithMany(p => p.Itens) 
                .HasForeignKey(i => i.PedidoId); 
        }

    }
}