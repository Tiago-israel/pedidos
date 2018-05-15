using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Models
{
    [Table("produto")]
    public class Produto : Modelo
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
