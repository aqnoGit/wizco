using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Models
{
    public class Pedido
    {
       [JsonIgnore]
       public Guid Id { get; set; }
       public string? ClienteNome { get; set; }
       [JsonIgnore]
       public DateTime DataCriacao { get; set; }
       public Status Status { get; set; } 
       public int ValorTotal { get; set; } 
       public List<ItemPedido> Itens  { get; set; }
       
    public Pedido()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.UtcNow;
            Status = Status.NOVO;
            Itens = new();
        }
    }
}