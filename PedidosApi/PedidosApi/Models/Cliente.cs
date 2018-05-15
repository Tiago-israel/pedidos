using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Models
{
    
    public class Cliente : Modelo
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
