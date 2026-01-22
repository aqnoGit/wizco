using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDePedidos.Models;
using GerenciadorDePedidos.Models.DTO;

namespace GerenciadorDePedidos.Utils
{
    public class ValidacaoUtils
    {
       public void ValidarFazerPedido(PedidoRequest request)
        {
            if(request.Itens == null || !request.Itens.Any())
            {
                throw new Exception("Deve haver ao menos um item");
            }

            if(request.Itens.Any(i=> i.Quantidade <= 0))
            {
                throw new Exception("Quantidade deve ser maior que 0");
            }
        }

        public void ValidarCancelarPedido(Pedido pedido)
        {
            if (pedido.Status == Status.PAGO)
            {
               throw new Exception("Pedido pago não pode ser cancelado."); 
            }
        }
    }
}