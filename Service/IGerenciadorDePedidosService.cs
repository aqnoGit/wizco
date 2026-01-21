using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDePedidos.Models;

namespace GerenciadorDePedidos.Service
{
    public interface IGerenciadorDePedidosService
    {
      Task<Pedido> FazerPedido(Pedido pedido); 
      Task<Pedido> CancelarPedido(Guid id);  
    }
}