using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDePedidos.Models;
using GerenciadorDePedidos.Models.DTO;
using GerenciadorDePedidos.Repository;
using GerenciadorDePedidos.Utils;

namespace GerenciadorDePedidos.Service
{
    public class GerenciadorDePedidosService(IGerenciadorDePedidos gerenciadorDePedidos) : IGerenciadorDePedidosService
    {
        private readonly IGerenciadorDePedidos _gerenciadorDePedidos = gerenciadorDePedidos;
        readonly ValidacaoUtils _validacao = new();
        readonly GerenciadorAssembler _gerenciadorAssembler = new();

        public async Task<PedidoResponse> FazerPedido(PedidoRequest request)
        {           
            _validacao.ValidarFazerPedido(request);
            var pedido = _gerenciadorAssembler.MapearRequestParaEntidadeNovoPedido(request); 
            await _gerenciadorDePedidos.FazerPedido(pedido);
            var response = _gerenciadorAssembler.MapearPedidoParaResponse(pedido); 
            return response;
        }

        public async Task<PedidoResponse> AtualizarPedido(Guid id, PedidoRequest request) 
        { 
            var consultaPedidoId = await _gerenciadorDePedidos.ConsultarPorId(id) ?? throw new Exception("Pedido não encontrado.");
            var pedidoAtualizar = _gerenciadorAssembler.MapearRequestParaEntidadeAtualizacao(consultaPedidoId, request); 
            await _gerenciadorDePedidos.AtualizarPedido(pedidoAtualizar); 
            var response = _gerenciadorAssembler.MapearPedidoParaResponse(pedidoAtualizar); 
            return response;
        }

        public async Task<PedidoResponse> CancelarPedido(Guid id) { 
            var pedido = await _gerenciadorDePedidos.ConsultarPorId(id) ?? throw new Exception("Pedido não encontrado.");
            _validacao.ValidarCancelarPedido(pedido);  
            pedido.Status = Status.CANCELADO; 
            await _gerenciadorDePedidos.AtualizarPedido(pedido);      
            var response = _gerenciadorAssembler.MapearPedidoParaResponse(pedido); 
            return response;
        }
    }   
}