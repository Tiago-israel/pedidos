using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Models
{
    [Table("pedidoitem")]
    public class PedidoItem : Modelo
    {
        public long Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid IdProduto { get; set; }
        public Guid IdPedido { get; set; }


        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }
    }
}
