using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Models.DTO
{
    public class ItemPedidoRequest
    {
        public string? ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public int PrecoUnitario { get; set; }
    }
}