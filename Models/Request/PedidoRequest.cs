using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Models.DTO
{
    public class PedidoRequest
    {     
       public string? ClienteNome { get; set; }
       public Status Status { get; set; }  
       public List<ItemPedidoRequest>? Itens  { get; set; }
    }      
}