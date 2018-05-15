using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosApi.Interfaces;
using PedidosApi.Interfaces.Services;
using PedidosApi.Models;
using PedidosApi.Repository;

namespace PedidosApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Clientes")]
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{id}")]
        public IActionResult buscarPorId(Guid Id)
        {
            var cliente = _clienteService.BuscarPorId(Id);
            return Ok(cliente);
        }

        [HttpGet()]
        public IActionResult buscarTodos() {
            var clientes = _clienteService.BuscarTodos();
            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult salvar([FromBody]Cliente cliente)
        {
            _clienteService.Salvar(cliente);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Editar(Guid Id, [FromBody]Cliente cliente) {
            _clienteService.Editar(Id, cliente);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(Guid Id)
        {
            _clienteService.Excluir(Id);
            return Ok();
        }
        
    }
}