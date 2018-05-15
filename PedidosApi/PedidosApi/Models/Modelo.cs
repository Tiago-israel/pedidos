using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Models
{
    public abstract class Modelo
    {
        public Guid Id { get; set; }
        public DateTime AssinaturaAlteracao { get; set; } = DateTime.Now;
    }
}
