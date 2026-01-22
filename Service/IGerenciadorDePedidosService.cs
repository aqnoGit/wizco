using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDePedidos.Models;
using GerenciadorDePedidos.Models.DTO;

namespace GerenciadorDePedidos.Service
{
    public interface IGerenciadorDePedidosService
    {
      Task<PedidoResponse> FazerPedido(PedidoRequest request); 
      Task<PedidoResponse> AtualizarPedido(Guid id, PedidoRequest request);
      Task<PedidoResponse> CancelarPedido(Guid id);  
    }
}