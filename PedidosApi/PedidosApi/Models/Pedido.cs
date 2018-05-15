using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Models
{
    
    public class Pedido : Modelo
    {
        
        public Guid IdCliente { get; set; }
        public DateTime Data { get; set; }
        public long Numero { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
