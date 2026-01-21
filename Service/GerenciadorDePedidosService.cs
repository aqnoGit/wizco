using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDePedidos.Models;
using GerenciadorDePedidos.Repository;

namespace GerenciadorDePedidos.Service
{
    public class GerenciadorDePedidosService : IGerenciadorDePedidosService
    {
        private readonly IGerenciadorDePedidos _gerenciadorDePedidos;
        public GerenciadorDePedidosService(IGerenciadorDePedidos gerenciadorDePedidos)
        {
            _gerenciadorDePedidos = gerenciadorDePedidos;
        }

    public async Task<Pedido> FazerPedido(Pedido pedido)
        {
            if(pedido.Itens == null || !pedido.Itens.Any())
            {
                throw new Exception("Deve haver ao menos um item");
            }

            if(pedido.Itens.Any(i=> i.Quantidade <= 0))
            {
                throw new Exception("Quantidade deve ser maior que 0");
            }

            pedido.ValorTotal = pedido.Itens.Sum(i => i.Quantidade * i.PrecoUnitario); 
            await _gerenciadorDePedidos.FazerPedido(pedido); 
            return pedido;
        }
        public async Task<Pedido> CancelarPedido(Guid id) { 
            var pedido = await _gerenciadorDePedidos.ConsultarPorId(id); 
            if (pedido == null)
            {
                throw new Exception("Pedido não encontrado.");
            }  
            if (pedido.Status == Status.PAGO)
            {
               throw new Exception("Pedido pago não pode ser cancelado."); 
            }  
            pedido.Status = Status.CANCELADO; 
            await _gerenciadorDePedidos.AtualizarPedido(pedido); return pedido; }
    }   
}