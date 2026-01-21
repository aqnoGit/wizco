using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Models
{
    public class Pedido
    {
       public Guid Id { get; set; }
       public string? ClienteNome { get; set; }
       public DateTime DataCriacao { get; set; }
       public Status Status { get; set; }
       public int ValorTotal { get; set; } 
    }
}