using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Models
{
    public class PedidoResponse
    {
       public Guid Id { get; set; }
       public string? ClienteNome { get; set; }
       public DateTime DataCriacao { get; set; }
       public Status Status { get; set; } 
       public int ValorTotal { get; set; } 
       public List<ItemPedidoResponse>? Itens  { get; set; }
       
   }
}