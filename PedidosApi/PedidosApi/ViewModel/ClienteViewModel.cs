using Microsoft.AspNetCore.Mvc;
using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.ViewModel
{
    public class ClienteViewModel : Modelo
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public FileStreamResult Foto { get; set; }
    }
}
