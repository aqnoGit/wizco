using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDePedidos.Models;

namespace GerenciadorDePedidos.Repository
{
    public interface IGerenciadorDePedidos
    {
        Task<Pedido> ConsultarPorId(Guid id);
        Task<List<Pedido>> ConsultarPorStatus(Status? status);
        Task FazerPedido(Pedido pedido);
        Task AtualizarPedido(Pedido pedido);
    }
}