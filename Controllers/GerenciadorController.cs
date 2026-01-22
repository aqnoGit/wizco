using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.Models;
using GerenciadorDePedidos.Models.DTO;
using GerenciadorDePedidos.Repository;
using GerenciadorDePedidos.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GerenciadorDePedidos.Controllers
{
    [ApiController]
    [Route("wizco/gerenciador-de-pedidos")]
    public class GerenciadorController : Controller
    {
        private readonly IGerenciadorDePedidosService _gerenciadorDePedidosService;
        private readonly IGerenciadorDePedidos _gerenciadorDePedidos;
        public GerenciadorController(IGerenciadorDePedidosService gerenciadorDePedidosService,IGerenciadorDePedidos gerenciadorDePedidos)
        {
            _gerenciadorDePedidosService = gerenciadorDePedidosService;
            _gerenciadorDePedidos = gerenciadorDePedidos;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarPedidos(PedidoRequest request)
        {
            try { 
                var response = await _gerenciadorDePedidosService.FazerPedido(request);
                Response.Headers.Add("X-Mensagem", "Pedido realizado com sucesso!"); 
                return CreatedAtAction(nameof(ObterPedido), new { id = response.Id }, response); 
            } 
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message); 
            }
        }

        [HttpGet("consultarPorId/{id}")] 
        public async Task<IActionResult> ObterPedido(Guid id) 
        { 
            var response = await _gerenciadorDePedidos.ConsultarPorId(id); 
            if (response == null)
            {
               return NoContent(); 
            }  
            return Ok(response); 
        }

        [HttpGet("consultarPorStatus")] 
        public async Task<IActionResult> ObterPorStatus([FromQuery] Status? status) 
        { 
            var response = await _gerenciadorDePedidos.ConsultarPorStatus(status); 
            if (response == null)
            {
               return NoContent(); 
            }
            return Ok(response); 
        }

        [HttpPut("atualizar/{id}")] 
        public async Task<IActionResult> AtualizarPedido(Guid id, PedidoRequest request) 
        { 
            try { 
                var response = await _gerenciadorDePedidosService.AtualizarPedido(id, request); 
                if (response == null) { 
                    return NotFound("Pedido não encontrado."); 
                } 
                return Ok(new{Mensagem = "Pedido atualizado com sucesso!", PedidoResponse = response}); 
            } catch (Exception ex) { 
                return BadRequest(ex.Message); 
            } 
        }

        [HttpPut("cancelar/{id}")] 
        public async Task<IActionResult> CancelarPedido(Guid id) 
        { 
            try { 
                var response = await _gerenciadorDePedidosService.CancelarPedido(id); 
                return Ok(new{Mensagem = "Pedido cancelado com sucesso!", PedidoResponse = response}); 
            } catch (Exception ex) 
            { 
                return BadRequest(ex.Message); 
            } 
        }
    }
}