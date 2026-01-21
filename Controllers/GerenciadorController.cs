using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.Models;
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
        public async Task<IActionResult> AdicionarPedidos(Pedido pedido)
        {
            try { 
                var novoPedido = await _gerenciadorDePedidosService.FazerPedido(pedido); 
                return CreatedAtAction(nameof(ObterPedido), new { id = novoPedido.Id }, novoPedido); 
            } 
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message); 
            }
        }

        [HttpGet("consultarPorId/{id}")] 
        public async Task<IActionResult> ObterPedido(Guid id) 
        { 
            var pedido = await _gerenciadorDePedidos.ConsultarPorId(id); 
            if (pedido == null)
            {
               return NotFound(); 
            }  
            return Ok(pedido); 
        }

        [HttpGet("consultarPorStatus")] 
        public async Task<IActionResult> ObterPorStatus([FromQuery] Status? status) 
        { 
            var pedidos = await _gerenciadorDePedidos.ConsultarPorStatus(status); 
            return Ok(pedidos); 
        }

        [HttpPut("cancelar/{id}")] 
        public async Task<IActionResult> CancelarPedido(Guid id) 
        { 
            try { 
                var pedido = await _gerenciadorDePedidosService.CancelarPedido(id); 
                return Ok(pedido); 
            } catch (Exception ex) 
            { 
                return BadRequest(ex.Message); 
            } 
        }
    }
}