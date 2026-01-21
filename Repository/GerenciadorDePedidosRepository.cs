using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDePedidos.Repository
{
    public class GerenciadorDePedidosRepository : IGerenciadorDePedidos   
    {
        private readonly AppDbContext _appDbContext;
        public GerenciadorDePedidosRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task FazerPedido(Pedido pedido)
        {
           _appDbContext.PedidosBD.Add(pedido);
           await _appDbContext.SaveChangesAsync();
        }
        public async Task AtualizarPedido(Pedido pedido)
        {
            _appDbContext.PedidosBD.Update(pedido);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<Pedido> ConsultarPorId(Guid id) => await _appDbContext.PedidosBD.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<Pedido>> ConsultarPorStatus(Status? status)
        {
            var query = _appDbContext.PedidosBD.Include(p=> p.Itens).AsQueryable();
            if (status.HasValue)
            {
                query = query.Where(p=> p.Status == status);
                return await query.ToListAsync();
            }
            throw new NotImplementedException();
        }
    }
}