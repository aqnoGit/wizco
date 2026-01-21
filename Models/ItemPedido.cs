using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Models
{
    public class ItemPedido
    {
        public int PedidoId { get; set; }
        public string? ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public int PrecoUnitario { get; set; }
    }
}