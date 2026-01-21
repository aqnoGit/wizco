using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Models
{
    public class ItemPedido
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string? ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public int PrecoUnitario { get; set; }
        [JsonIgnore]
        public Guid PedidoId { get; set; } 
        [JsonIgnore]
        public Pedido? Pedido { get; set; }
    }
}