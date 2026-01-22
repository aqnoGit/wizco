using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDePedidos.Models;
using GerenciadorDePedidos.Models.DTO;

namespace GerenciadorDePedidos.Utils
{
    public class GerenciadorAssembler
    {
        public Pedido MapearRequestParaEntidadeNovoPedido(PedidoRequest request)
        {
            var pedido = new Pedido
            {
               ClienteNome = request.ClienteNome,
               Status = request.Status,
               Itens = request.Itens.Select(itemDoPedido => new ItemPedido
               {
                  ProdutoNome = itemDoPedido.ProdutoNome,
                  Quantidade = itemDoPedido.Quantidade,
                  PrecoUnitario = itemDoPedido.PrecoUnitario 
               }).ToList()
            };

            pedido.ValorTotal = pedido.Itens.Sum(i => i.Quantidade * i.PrecoUnitario); 
            return pedido;
        }
        public Pedido MapearRequestParaEntidadeAtualizacao(Pedido pedidoAtualizar, PedidoRequest request)
        {
            pedidoAtualizar.ClienteNome = request.ClienteNome; 
            pedidoAtualizar.Status = request.Status; 
            pedidoAtualizar.Itens = request.Itens.Select(itemDoPedido => new ItemPedido 
            { 
                ProdutoNome = itemDoPedido.ProdutoNome, 
                Quantidade = itemDoPedido.Quantidade, 
                PrecoUnitario = itemDoPedido.PrecoUnitario, 
                PedidoId = pedidoAtualizar.Id 
            }).ToList();
            pedidoAtualizar.ValorTotal = pedidoAtualizar.Itens.Sum(i => i.Quantidade * i.PrecoUnitario); 
            return pedidoAtualizar;
        }

        public PedidoResponse MapearPedidoParaResponse(Pedido pedido) 
        { 
            var response = new PedidoResponse
            { 
                Id = pedido.Id, 
                ClienteNome = pedido.ClienteNome, 
                Status = pedido.Status,
                ValorTotal = pedido.ValorTotal, 
                Itens = new List<ItemPedidoResponse>() 
            };         
            
            foreach (var item in pedido.Itens) 
            { 
                var itemResponse = new ItemPedidoResponse 
                { 
                    ProdutoNome = item.ProdutoNome, 
                    Quantidade = item.Quantidade, 
                    PrecoUnitario = item.PrecoUnitario 
                }; 
            response.Itens.Add(itemResponse); 
            } 
            return response;           
        }
    }
}