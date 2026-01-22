using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Models
{
    public class ItemPedidoResponse
    {
        public Guid Id { get; set; }
        public string? ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public int PrecoUnitario { get; set; }
        public Guid PedidoId { get; set; } 

    }
}