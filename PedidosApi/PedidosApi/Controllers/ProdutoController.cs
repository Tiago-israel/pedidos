using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosApi.Interfaces.Services;
using PedidosApi.Models;

namespace PedidosApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult BuscarTodos() {
            var produtos = _produtoService.BuscarTodos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id) {
            var produto = _produtoService.BuscarPorId(id);
            if(produto != null)
            {
                return Ok(produto);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(Guid id) {
            var produto = _produtoService.BuscarPorId(id);
            if (produto != null)
            {
                _produtoService.Excluir(id);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Salvar([FromBody]Produto produto)
        {
            var produtoDb = _produtoService.Salvar(produto);
            if (produto != null) {
                return Ok(produto);
            }
            return BadRequest();
        }
    }
}